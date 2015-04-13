Shader "Custom/Alpha_Self_Illumin" {
 Properties {
     _Color ("Main Color", Color) = (1,1,1,1)
     _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
     _Illum ("Illumin (RGB)", 2D) = "white" {}    
     _EmissionLM ("Emission (Lightmapper)", Float) = 0
     _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
  
 }
 SubShader {
 
     Tags { "RenderType"="Transparent" "Queue"="Transparent" }
     //LOD 200
     Cull Back
     Zwrite Off
 
 CGPROGRAM
 #pragma surface surf Lambert alpha
  

 sampler2D _MainTex;
 sampler2D _Illum;
 fixed4 _Color;
 float _Cutoff;
    
 struct Input {
     float2 uv_MainTex;
     float2 uv_Illum;
 };

 void surf (Input IN, inout SurfaceOutput o) {
     fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
     fixed4 c = tex * _Color;
     o.Albedo = c.rgb;
     o.Emission = c.rgb * tex2D(_Illum, IN.uv_Illum).a;
     o.Alpha = _Cutoff;
 }
 ENDCG
 
 } 
 FallBack "Self-Illumin/VertexLit"
 }
