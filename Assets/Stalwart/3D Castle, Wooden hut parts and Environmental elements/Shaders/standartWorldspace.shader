Shader "Custom/Standart - Worldspace"
{
    Properties 
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _TopTex ("Top Texture Base (RGB)", 2D) = "white" {}
        _WallTex ("Side Texture Base (RGB)", 2D) = "white" {}
        _Scale ("Texture Scale", Float) = 1.0
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader 
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
    
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0
    
        sampler2D _TopTex;
        sampler2D _WallTex;
        fixed4 _Color;
        half _Glossiness;
        half _Metallic;
        float _Scale;
    
        struct Input
        {
            float3 worldNormal;
            float3 worldPos;
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 UV;
            fixed4 c;
        
            if (abs(IN.worldNormal.x)>0.5)
            {
                UV = IN.worldPos.zy; // side
                c = tex2D(_WallTex, UV* _Scale); // use WALLSIDE texture
            }
            else if (abs(IN.worldNormal.z)>0.5)
            {
                UV = IN.worldPos.xy; // front
                c = tex2D(_WallTex, UV* _Scale); // use WALL texture
            }
            else
            {
                UV = IN.worldPos.xz; // top
                c = tex2D(_TopTex, UV* _Scale); // use FLR texture
            }
        
            o.Albedo = c.rgb * _Color;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    
    Fallback "Diffuse"
}
