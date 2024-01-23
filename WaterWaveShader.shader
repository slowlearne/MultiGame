Shader "Custom/WaterWaveShader"
{
    Properties
    {
        _WaveSpeed ("Wave Speed", Range (0, 10)) = 1
        _WaveHeight ("Wave Height", Range (0, 1)) = 0.1
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }

    CGINCLUDE
    #include "UnityCG.cginc"
    
    struct appdata
    {
        float4 vertex : POSITION;
        float3 normal : NORMAL;
    };

    struct v2f
    {
        float4 pos : POSITION;
        float4 color : COLOR;
    };

    uniform float _WaveSpeed;
    uniform float _WaveHeight;

    v2f vert(appdata v)
    {
        v2f o;
        o.pos = UnityObjectToClipPos(v.vertex);
        float wave = _WaveHeight * sin(_Time.y * _WaveSpeed + v.vertex.x);
        o.pos.y += wave;
        return o;
    }
    ENDCG

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG
    }

    FallBack "Diffuse"
}
