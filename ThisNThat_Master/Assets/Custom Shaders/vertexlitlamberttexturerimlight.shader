//basic lambert CG shader with rim light

Shader "CG Shaders/Lambert/Vertex Lit Rim Light"
{
	Properties
	{
		_diffuseColor("Diffuse Color", Color) = (1,1,1,1)
		_diffuseMap("Diffuse", 2D) = "white" {}
		//The Frensel Rim Light properties
		_FrenselPower ("Rim Power", Range(1.0, 10.0)) = 2.5
		//properties can be declared twice to allow sliders and numbers to be used on the same attribute
		//the second one i usually leave a space in the name, to keep the box from expanding
		_FrenselPower (" ", Float) = 2.5		
		_rimColor("Rim Color", Color) = (1,1,1,1)
		
	}
	SubShader
	{
		Pass
		{
			Tags { "LightMode" = "ForwardBase" } 
            
			CGPROGRAM
			
			#pragma vertex vShader
			#pragma fragment pShader
			#include "UnityCG.cginc"
			#pragma multi_compile_fwdbase
			
			uniform fixed3 _diffuseColor;
			uniform sampler2D _diffuseMap;
			uniform half4 _diffuseMap_ST;			
			uniform fixed4 _LightColor0; 
			//The power of the frensel Rim Light
			uniform half _FrenselPower;
			uniform fixed4 _rimColor;
			
			struct app2vert {
				float4 vertex 	: 	POSITION;
				fixed2 texCoord : 	TEXCOORD0;
				fixed4 normal 	:	NORMAL;
			};
			struct vert2Pixel
			{
				float4 pos 						: 	SV_POSITION;
				fixed2 uvs						:	TEXCOORD0;	
				fixed3 lighting					:	TEXCOORD1;
			};
			
			fixed lambert(fixed3 N, fixed3 L)
			{
				return saturate(dot(N, L));
			}
			//frensel function
			fixed frensel(fixed3 V, fixed3 N)
			{	
				//similar to the lambert function, we run a dotProduct on the View and Normal Vectors
				//We then saturate it to return a value between 1 and 0 and invert that via 1 - value
				//We power this to control the falloff
				return pow(1 - saturate(dot(V,N)), _FrenselPower);
			}
			vert2Pixel vShader(app2vert IN)
			{
				vert2Pixel OUT;
				float4x4 WorldViewProjection = UNITY_MATRIX_MVP;
				float4x4 WorldInverseTranspose = _World2Object; 
				float4x4 World = _Object2World;
							
				OUT.pos = mul(WorldViewProjection, IN.vertex);
				OUT.uvs = IN.texCoord.xy;	
				
				fixed3 normalDir = normalize(mul(IN.normal, WorldInverseTranspose).xyz);
				fixed3 posWorld = mul(World, IN.vertex).xyz;
				
				//vertex lights
				fixed3 vertexLighting = fixed3(0.0, 0.0, 0.0);
				#ifdef VERTEXLIGHT_ON
				 for (int index = 0; index < 4; index++)
					{    
						half3 vertexToLightSource = half3(unity_4LightPosX0[index], unity_4LightPosY0[index], unity_4LightPosZ0[index]) - posWorld;
						fixed attenuation  = (1.0/ length(vertexToLightSource)) *.5;	
						fixed3 diffuse = unity_LightColor[index].xyz * lambert(normalDir, normalize(vertexToLightSource)) * attenuation;
						vertexLighting = vertexLighting + diffuse;
					}
					vertexLighting = saturate( vertexLighting );
				#endif
				
				//Main Light calculation - includes directional lights
				half3 vertexToLightSource =_WorldSpaceLightPos0.xyz - (posWorld*_WorldSpaceLightPos0.w);
				fixed attenuation  = lerp(1.0, 1.0/ length(vertexToLightSource), _WorldSpaceLightPos0.w);				
				fixed3 lightDirection = normalize(vertexToLightSource);
				fixed3 ambientL = UNITY_LIGHTMODEL_AMBIENT.xyz;
				
				fixed diffuseL = lambert(normalDir, lightDirection);
				fixed3 diffuse = _LightColor0.xyz* diffuseL * attenuation;
				
				//At this point we can calculate the rim light
				//calculate the direction to the camera from the world position
				//camera position comes in via "UnityCG.cginc"
				fixed3 viewDir = normalize(_WorldSpaceCameraPos - posWorld);
				//run the frensel function to get a base for the rim light
				fixed rim = frensel(normalDir, viewDir);
				//get a dot product mask of the normals vs the up vector, wrapped slightly
				fixed3 upV = fixed3(0,1,0);
				fixed mask = saturate(dot(upV,normalDir)* 0.5 + 0.5);	
				//multiply the rimlight by up vector mask
				//this means  the light will seem to come from above	
				rim *= mask;				
				//mask via view vector and negative up vector, with a lot of wrapping
				//This is to reduce obviously fake lighting when looking from above
				mask = saturate(dot(upV,-viewDir)+ 1.75);
				//multiply the rimLight by the mask
				rim *= mask;
				//we can add some bloom along the edges that the key light comes from
				//this just looks nice
				diffuse += diffuse * rim;
				//finally multiply the rimlight by the inverse of the key light
				//this means the rim light will only be visible in shadows and the light will seem to come from above
				//99% of 3 point lighting rigs have a back/rim light opposite the key coming from above, which we attempt to approximate
				//need to convert to fixed 3 for color multiplication
				
				fixed3 rimLight= rim *(1-diffuseL)* _rimColor.xyz ;	
				OUT.lighting = saturate(ambientL + vertexLighting + diffuse + rimLight);
				
				return OUT;
			}
			
			fixed4 pShader(vert2Pixel IN): COLOR
			{
				fixed4 outColor;							
				half2 diffuseUVs = TRANSFORM_TEX(IN.uvs, _diffuseMap);
				fixed3 texSample = tex2D(_diffuseMap, diffuseUVs);
				outColor = fixed4(IN.lighting * texSample * _diffuseColor,1.0);
				return outColor;
			}
			
			ENDCG
		}	
		
		//the second pass for additional lights
		Pass
		{
			Tags { "LightMode" = "ForwardAdd" } 
			Blend One One 
			
			CGPROGRAM
			#pragma vertex vShader
			#pragma fragment pShader
			#include "UnityCG.cginc"
			
			uniform fixed3 _diffuseColor;
			uniform sampler2D _diffuseMap;
			uniform half4 _diffuseMap_ST;
			
			uniform fixed4 _LightColor0; 
			
			struct app2vert {
				float4 vertex 	: 	POSITION;
				fixed2 texCoord : 	TEXCOORD0;
				fixed4 normal 	:	NORMAL;
			};
			struct vert2Pixel
			{
				float4 pos 						: 	SV_POSITION;
				fixed2 uvs						:	TEXCOORD0;	
				fixed3 lighting					:	TEXCOORD1;
			};
			
			fixed lambert(fixed3 N, fixed3 L)
			{
				return saturate(dot(N, L));
			}
			vert2Pixel vShader(app2vert IN)
			{
				vert2Pixel OUT;
				float4x4 WorldViewProjection = UNITY_MATRIX_MVP;
				float4x4 WorldInverseTranspose = _World2Object; 
				float4x4 World = _Object2World;
				
				OUT.pos = mul(WorldViewProjection, IN.vertex);
				OUT.uvs = IN.texCoord.xy;	
				
				fixed3 normalDir = normalize(mul(IN.normal, WorldInverseTranspose).xyz);
				half3 vertexToLightSource =_WorldSpaceLightPos0.xyz- ( mul(World, IN.vertex).xyz *_WorldSpaceLightPos0.w);
				fixed attenuation  = lerp(1.0, 1.0/ length(vertexToLightSource), _WorldSpaceLightPos0.w);				
				fixed3 lightDirection = normalize(vertexToLightSource);
				
				fixed diffuseL = lambert(normalDir, lightDirection);				
				fixed3 diffuse = _LightColor0.xyz* diffuseL * attenuation;
				
				OUT.lighting = diffuse;
				
				return OUT;
			}
			fixed4 pShader(vert2Pixel IN): COLOR
			{
				fixed4 outColor;							
				half2 diffuseUVs = TRANSFORM_TEX(IN.uvs, _diffuseMap);
				fixed3 texSample = tex2D(_diffuseMap, diffuseUVs);
				outColor = fixed4(IN.lighting * texSample * _diffuseColor,1.0);
				return outColor;
			}
			
			ENDCG
		}	
		
	}
}