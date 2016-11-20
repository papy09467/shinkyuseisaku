//水の屈折、波の再現シェーダー
//長谷川弘明

Shader "Custom/Water" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
    _MainTex ("Base (RGB) RefStrength (A)", 2D) = "white" {}
    _Cube ("Reflection Cubemap", Cube) = "_Skybox" { TexGen CubeReflect }
    _BumpMap ("Normalmap", 2D) = "bump" {}
}
 
SubShader {
    Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
    Cull Off Lighting Off
    LOD 300
   
 
CGPROGRAM
#pragma surface surf Lambert alpha vertex:vert
 
sampler2D _MainTex;
sampler2D _BumpMap;
samplerCUBE _Cube;
 
fixed4 _Color;
fixed4 _ReflectColor;
 
struct Input {
    float2 uv_MainTex;
    float2 uv_BumpMap;
    float3 worldRefl;
    float3 viewDir;
    float3 worldNormal;
    INTERNAL_DATA
};
 
void vert (inout appdata_full v) {
    float phase = _Time * 30.0;
    float4 wpos = mul( unity_ObjectToWorld, v.vertex);
    float offset = (wpos.x + (wpos.z * 0.2)) * 0.5;
    wpos.y = sin(phase + offset) * 0.1;
    v.vertex = mul(unity_WorldToObject, wpos);
}
 
void surf (Input IN, inout SurfaceOutput o) {

	//光の屈折（空気→水）
    float3 refractVect = refract( normalize( IN.viewDir ), normalize( IN.worldNormal ), 1.3);
    o.Albedo  = texCUBE( _Cube, refractVect ).rgb;
    o.Albedo += texCUBE( _Cube, IN.worldRefl ).rgb * 0.5;

    //流れる速度
    fixed2 uv = IN.uv_MainTex;
	uv.x += 0.4 * _Time;
	uv.y += 0.7 * _Time;
	o.Albedo += tex2D (_MainTex, uv);

	//発光調整
    fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
    fixed4 c = tex * _Color;
    o.Emission = c.rgb * 0.01;

    //透明度
    o.Alpha = 1.0;
}
ENDCG
}
 
FallBack "Reflective/VertexLit"
}