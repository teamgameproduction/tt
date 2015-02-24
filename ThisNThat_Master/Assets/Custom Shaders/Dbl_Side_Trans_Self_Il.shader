Shader "Self-Illumin/Dbl_Side_Trans" 
{
    Properties 
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
        _Illum ("Illumin", 2D) = "white" {}
        _EmissionLM ("Emmisive (LightMapper)", Float) = 0
    }
 
    SubShader 
    {
        Tags 
        {
        "RenderType"="Transparent"
        "IgnoreProjector"="False"
        "Queue"="Transparent"
        }
        // Render into depth buffer only
        Pass 
        {
            ZWrite On
            Blend SrcAlpha OneMinusSrcAlpha
            ColorMask RGB
            Cull off
            Material 
            {
                Diffuse [_Color]
                Ambient [_Color]
                Emission[_Color]
            }
          	 
            Lighting On
            
            SetTexture [_MainTex] 
            {
                Combine texture * primary DOUBLE, texture * primary
            }
            
        } 
    }
}