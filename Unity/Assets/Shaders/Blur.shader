Shader "Custom/Blur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0, 30)) = 30
        _Samples ("Number of Samples", Range(1, 16)) = 16
    }
    SubShader
    {
        Tags
        {
            "Queue"="Transparent" "RenderType"="Transparent"
        }
        Pass
        {
            Cull Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _BlurSize;
            int _Samples;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed3 color = 0;
                float alpha = 0;
                for (int s = 0; s < _Samples; s++)
                {
                    float angle = 2.0 * UNITY_PI * s / _Samples;
                    float2 offset = float2(cos(angle), sin(angle)) * _BlurSize * _MainTex_TexelSize.xy;
                    fixed4 sample = tex2D(_MainTex, saturate(i.uv + offset));
                    color += sample.rgb * sample.a;
                    alpha += sample.a;
                }
                if (alpha > 0) color /= alpha;
                return fixed4(color, alpha / _Samples);
            }
            ENDCG
        }
    }
}