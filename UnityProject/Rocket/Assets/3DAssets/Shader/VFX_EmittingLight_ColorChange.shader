Shader "VFX/EmittingLight_ColorChange" {
    Properties {
        _TintColor ("Color_A", Color) = (0,0.2551727,1,1)
        _Color_B ("Color_B", Color) = (0.7379308,0,1,1)
        Textures ("MainTex", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _Spoeed ("Spoeed", Float ) = 1
        _EdgeOpacity ("EdgeOpacity", Float ) = 0.8
        _Intensity ("Intensity", Float ) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D Textures; uniform float4 Textures_ST;
            uniform float _EdgeOpacity;
            uniform float _Spoeed;
            uniform float _Intensity;
            uniform float4 _TintColor;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float4 _Color_B;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {

                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 node_1878 = (1.0 - _Mask_var.rgb);
                float4 node_5906 = _Time + _TimeEditor;
                float2 PannerY = (i.uv0+(node_5906.g*_Spoeed)*float2(0,1));
                float4 Textures_var = tex2D(Textures,TRANSFORM_TEX(PannerY, Textures));
                float3 emissive = ((((_TintColor.rgb*_Mask_var.rgb)+(node_1878*_Color_B.rgb))*i.vertexColor.rgb*Textures_var.rgb*_Intensity)*(((_Mask_var.a*_TintColor.a)+(node_1878.r*_Color_B.a))*i.vertexColor.a*Textures_var.a*(1.0 - (_EdgeOpacity*length(abs((frac(abs(i.uv1.g))-0.5)))))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }

}
