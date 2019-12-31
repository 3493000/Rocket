// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "UI/ImageGreyShader"
{
    Properties
    {
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		[MaterialToggle] _Toggle ("Toggle", Float ) = 0
        _Color("Tint", Color) = (1,1,1,1)
    }

        SubShader
    {
        Tags
    {
        "Queue" = "Transparent"
        "IgnoreProjector" = "True"
        "RenderType" = "Transparent"
        "PreviewType" = "Plane"
        "CanUseSpriteAtlas" = "True"
    }

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
    {
        CGPROGRAM
#pragma vertex vert     
#pragma fragment frag   
uniform fixed _Toggle;
#include "UnityCG.cginc"     

        struct appdata_t
    {
        float4 vertex   : POSITION;
        float4 color    : COLOR;
        float2 texcoord : TEXCOORD0;
    };

    struct v2f
    {
        float4 vertex   : SV_POSITION;
        fixed4 color : COLOR;
        half2 texcoord  : TEXCOORD0;
    };

    sampler2D _MainTex;
    fixed4 _Color;

    v2f vert(appdata_t IN)
    {
        v2f OUT;
        OUT.vertex = UnityObjectToClipPos(IN.vertex);
        OUT.texcoord = IN.texcoord;
#ifdef UNITY_HALF_TEXEL_OFFSET     
        OUT.vertex.xy -= (_ScreenParams.zw - 1.0);
#endif     
        OUT.color = IN.color * _Color;
        return OUT;
    }

    fixed4 frag(v2f IN) : SV_Target
    {
        half4 color = tex2D(_MainTex,IN.texcoord)* IN.color;
        float3 grey = lerp(color.rgb, dot(color.rgb, fixed3(0.22, 0.707, 0.071)),_Toggle);
		//float3 finalColor = lerp( _node_8316_var.rgb, dot(_node_8316_var.r,float3(0,0,0)), _node_7228 );

		return half4(grey.rgb,color.a);
    }
        ENDCG
    }
    }
}
