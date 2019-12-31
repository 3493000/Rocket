Shader "VFX/UI/GlowShine_01" {
    Properties {
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _BaseTexture ("BaseTexture", 2D) = "white" {}
        _RulgeShape ("Rulge Shape", Float ) = 2
        _GlowIntensity ("Glow Intensity", Float ) = 2
        _Angle ("Angle", Range(-0.5, 0.5)) = 0
        _Speed ("Speed", Float ) = 1
        _Mask ("Mask", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="TransparentCutout"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform float4 _Color;
            uniform float _RulgeShape;
            uniform float _GlowIntensity;
            uniform float _Angle;
            uniform float _Speed;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
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
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                clip(_Mask_var.r - 0.5);

                float4 _BaseTexture_var = tex2D(_BaseTexture,TRANSFORM_TEX(i.uv0, _BaseTexture));
                float4 Time = _Time + _TimeEditor;
                float UvRot_ang = _Angle;
                float UvRot_spd = 1.0;
                float UvRot_cos = cos(UvRot_spd*UvRot_ang);
                float UvRot_sin = sin(UvRot_spd*UvRot_ang);
                float2 UvRot_piv = float2(0.5,0.5);
                float2 UvRot = (mul(i.uv0-UvRot_piv,float2x2( UvRot_cos, -UvRot_sin, UvRot_sin, UvRot_cos))+UvRot_piv);
                float3 emissive = (_Color.rgb*i.vertexColor.rgb*(i.vertexColor.a*(pow(((_BaseTexture_var.a*abs((frac(abs((UvRot+(Time.g*_Speed)*float2(-0.1,0)).r))-0.5)))*2.0),_RulgeShape)*_GlowIntensity)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        // Pass {
        //     Name "ShadowCaster"
        //     Tags {
        //         "LightMode"="ShadowCaster"
        //     }
        //     Offset 1, 1
        //     Cull Off
            
        //     CGPROGRAM
        //     #pragma vertex vert
        //     #pragma fragment frag
        //     #define UNITY_PASS_SHADOWCASTER
        //     #pragma multi_compile _ PIXELSNAP_ON
        //     #include "UnityCG.cginc"
        //     #include "Lighting.cginc"
        //     #pragma fragmentoption ARB_precision_hint_fastest
        //     #pragma multi_compile_shadowcaster
        //     #pragma only_renderers d3d9 d3d11 glcore gles gles3 
        //     #pragma target 3.0
        //     uniform sampler2D _Mask; uniform float4 _Mask_ST;
        //     struct VertexInput {
        //         float4 vertex : POSITION;
        //         float2 texcoord0 : TEXCOORD0;
        //     };
        //     struct VertexOutput {
        //         V2F_SHADOW_CASTER;
        //         float2 uv0 : TEXCOORD1;
        //     };
        //     VertexOutput vert (VertexInput v) {
        //         VertexOutput o = (VertexOutput)0;
        //         o.uv0 = v.texcoord0;
        //         o.pos = UnityObjectToClipPos(v.vertex );
        //         #ifdef PIXELSNAP_ON
        //             o.pos = UnityPixelSnap(o.pos);
        //         #endif
        //         TRANSFER_SHADOW_CASTER(o)
        //         return o;
        //     }
        //     float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
        //         float isFrontFace = ( facing >= 0 ? 1 : 0 );
        //         float faceSign = ( facing >= 0 ? 1 : -1 );
        //         float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
        //         clip(_Mask_var.r - 0.5);
        //         SHADOW_CASTER_FRAGMENT(i)
        //     }
        //     ENDCG
        // }
    }
    FallBack "Diffuse"

}
