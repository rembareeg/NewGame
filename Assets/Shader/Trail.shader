Shader "Custom/Trail"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
	Category{
		Tags { "Queue" = "Transparent" "RendererType" = "Transparent"}
		Blend One OneMinusSrcAlpha
		ZWrite On
		ZTest Less

		SubShader{
			Pass{
			}
		}
	}
   
}
