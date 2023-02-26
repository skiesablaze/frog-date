Shader "Custom/Diffuse - Worldspace" 
{
    Properties 
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _TopTex ("Top Texture Base (RGB)", 2D) = "white" {}
        _WallTex ("Side Texture Base (RGB)", 2D) = "white" {}
        _Scale ("Texture Scale", Float) = 1.0
    }
    SubShader 
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
    
        CGPROGRAM
        #pragma surface surf Lambert
        #pragma target 3.0
    
        sampler2D _TopTex;
        sampler2D _WallTex;
        fixed4 _Color;
        float _Scale;
    
        struct Input
        {
            float3 worldNormal;
            float3 worldPos;
        };
    
        void surf (Input IN, inout SurfaceOutput o)
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
        }
        ENDCG
    }
    
    Fallback "VertexLit"
}