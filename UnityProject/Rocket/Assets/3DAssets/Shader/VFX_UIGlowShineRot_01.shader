Shader "VFX/UI/GlowShinerRot_01" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _RulgeShape ("Rulge Shape", Float ) = 2
        _GlowIntensity ("Glow Intensity", Float ) = 2
        _Mask ("Mask", 2D) = "white" {}
        _Shine_Glow ("Shine_Glow", Range(-1, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 2.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _RulgeShape;
            uniform float _GlowIntensity;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _Shine_Glow;
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

                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = (_Color.rgb*i.vertexColor.rgb*_Mask_var.rgb);
                float3 finalColor = emissive;
                float4 node_1778 = _Time + _TimeEditor;
                float UVRot_ang = node_1778.g;
                float UVRot_spd = 1.0;
                float UVRot_cos = cos(UVRot_spd*UVRot_ang);
                float UVRot_sin = sin(UVRot_spd*UVRot_ang);
                float2 UVRot_piv = float2(0.5,0.5);
                float2 UVRot = (mul(i.uv0-UVRot_piv,float2x2( UVRot_cos, -UVRot_sin, UVRot_sin, UVRot_cos))+UVRot_piv);
                return fixed4(finalColor,(_Color.a*i.vertexColor.a*_Mask_var.a*(pow(((_Mask_var.r*abs((frac(abs((UVRot+_Shine_Glow*float2(0,0)).r))-0.5)))*2.0),_RulgeShape)*_GlowIntensity)));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"

}
