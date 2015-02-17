Shader "Custom/Double_Sided_Diffuse" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    }
 
    SubShader {
        Tags {"RenderType"="Diffuse"}
        // Render into depth buffer only
        Pass {
            ZWrite On
            ColorMask RGB
            Cull off
            Material {
                Diffuse [_Color]
                Ambient [_Color]
            }
            Lighting On
            SetTexture [_MainTex] {
                Combine texture * primary DOUBLE, texture * primary
            }
        } 
    }
}