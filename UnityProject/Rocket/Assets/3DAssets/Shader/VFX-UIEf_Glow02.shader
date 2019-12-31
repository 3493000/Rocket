Shader "VFX/UI/Ef_Glow02" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Glow_Max ("Glow_Max", Float ) = 0.9
        _Glow_Min ("Glow_Min", Float ) = 0.1
        _GlowColor ("GlowColor", Color) = (0.5,0.5,0.5,1)
        _Light ("Light", Float ) = 2
        _TimeSinLoop ("TimeSinLoop", Float ) = 5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True" "Queue"="Transparent" "RenderType"="Transparent" "CanUseSpriteAtlas"="True" "PreviewType"="Plane"
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Glow_Max;
            uniform float _Glow_Min;
            uniform float _TimeSinLoop;
            uniform float4 _GlowColor;
            uniform float _Light;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {

                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 Plnner = _Time + _TimeEditor;
                float3 emissive = ((_MainTex_var.rgb*i.vertexColor.rgb)*i.vertexColor.a*(_GlowColor.rgb*clamp(((sin((Plnner.g*_TimeSinLoop))+1.0)/2.0),_Glow_Min,_Glow_Max)*_Light));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"

}
