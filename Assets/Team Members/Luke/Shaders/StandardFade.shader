Shader "Custom/StandardFade" {
    Properties{
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _EmissionMap("Emission Map", 2D) = "black" {}
  [HDR] _EmissionColor("Emission Color", Color) = (0,0,0)
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _CurvePow("Fade Rate", Range(0,10)) = 3.0
        _MinDistance("Minimum Distance", float) = 2
        _MaxDistance("Maximum Distance", float) = 3
    	_ScrollX("Scroll X", float) = 0
    	_ScrollY("Scroll Y", float) = 0
    }
        SubShader{
        Tags { "RenderType" = "Opaque" }
        LOD 200


            CGPROGRAM
      // Physically based Standard lighting model, and enable shadows on all light types
      #pragma surface surf Standard fullforwardshadows

      // Use shader model 3.0 target, to get nicer looking lighting
      #pragma target 3.0


            sampler2D _MainTex;
            sampler2D _EmissionMap;

            struct Input {
                float2 uv_MainTex;
                float3 worldPos;
            };

            half _Glossiness;
            half _Metallic;
            float _MinDistance;
            float _MaxDistance;
            float _CurvePow;
            float _ScrollX;
            float _ScrollY;
            fixed4 _Color;
            fixed4 _EmissionColor;

            // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
            // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
            // #pragma instancing_options assumeuniformscaling
            UNITY_INSTANCING_BUFFER_START(Props)
                // put more per-instance properties here
            UNITY_INSTANCING_BUFFER_END(Props)

            void surf(Input IN, inout SurfaceOutputStandard o) {
                // Albedo comes from a texture tinted by color
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex + _Time.x*float2(_ScrollX, _ScrollY)) * _Color;
            	
                // Metallic and smoothness come from slider variables
                o.Metallic = _Metallic;
                o.Smoothness = _Glossiness;

                float distanceFromCamera = distance(IN.worldPos, float3(0, 0, 0));
                float fade = saturate((distanceFromCamera - _MinDistance) / _MaxDistance);
                fade = 1 - pow(1 - fade, _CurvePow);
            	
                half4 emission = tex2D(_EmissionMap, IN.uv_MainTex + _Time.x * float2(_ScrollX, _ScrollY)) * _EmissionColor;
            	
                o.Albedo = c.rgb * (1 - fade);
                o.Emission = emission * (1 - fade);
            }
            
            ENDCG
        }
	
            FallBack "Diffuse"
}
