Shader "VFX/UI/Ef_Glow03" {
    Properties {
        _ColorSweep ("ColorSweep", Color) = (1,1,1,1)
        _PatternTextures ("PatternTextures", 2D) = "white" {}
        _EdgeOpacity ("EdgeOpacity", Float ) = 2
        _Speed ("Speed", Float ) = 1
        _Intensity ("Intensity", Float ) = 1
        _Mask ("Mask", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {"IgnoreProjector"="True" "Queue"="Transparent" "RenderType"="Transparent" "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _PatternTextures; uniform float4 _PatternTextures_ST;
            uniform float _EdgeOpacity;
            uniform float _Speed;
            uniform float4 _ColorSweep;
            uniform float _Intensity;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
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

                float4 Plnner = _Time + _TimeEditor;
                float2 Transparency = (i.uv0+(Plnner.g*_Speed)*float2(0,-1));
                float4 _PatternTextures_var = tex2D(_PatternTextures,TRANSFORM_TEX(Transparency, _PatternTextures));
                float3 emissive = ((_ColorSweep.rgb*_PatternTextures_var.rgb)*i.vertexColor.rgb*_Intensity);
                float3 finalColor = emissive;
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                return fixed4(finalColor,(i.vertexColor.a*(1.0 - (_EdgeOpacity*length(abs((frac(abs(i.uv1.g))-0.5)))))*_ColorSweep.a*_PatternTextures_var.a*_Mask_var.r));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"

}
