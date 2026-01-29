Shader "Unlit/MatCap"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Matcap ("MatCap", 2D) = "white" {}
        [HDR]_RampCol("_RampCol",2D) = "white"{}
        _MatcapPopo("_MatcapPopo",2D) = "white"{}
        _MatcapPopower("_MatcapPopower",float) = 1
        _RampPower("_RampPower",float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal:NORMAL;
                float3 pos_world:TEXCOORD1;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float3 normal:NORMAL;
                float4 vertex : SV_POSITION;
                float3 pos_world:TEXCOORD1;
            };

            sampler2D _MainTex;
            sampler2D _Matcap;
            sampler2D _RampCol;
            sampler2D _MatcapPopo;
            float4 _MainTex_ST;
            float _RampPower;
            float _MatcapPopower;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float3 normal_World = mul(float4(v.normal,0.0),unity_WorldToObject);
                o.normal = normal_World;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.pos_world = mul(unity_ObjectToWorld,v.vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 normal_World = normalize(i.normal);
                float3 vDir = normalize(_WorldSpaceCameraPos.xyz - i.pos_world);
                half nDotv = dot(vDir,normal_World);
                
                float3 normal_viewspace = mul(UNITY_MATRIX_V,float4(normal_World,0.0)).xyz;
                float2 uv_matcap = (normal_viewspace.xy + float2(1,1))*0.5;
                float4 MatCapCol = tex2D(_Matcap,uv_matcap);
                uv_matcap+=_Time.y*0.1;
                float4 MatCapCol_1 = tex2D(_MatcapPopo,uv_matcap)*_MatcapPopower;
                float4 RampCol = tex2D(_RampCol,float2(1-nDotv,0.5))*_RampPower;
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv); 

                float4 Finial = MatCapCol*RampCol+MatCapCol_1;
                return Finial;
            }
            ENDCG
        }
    }
}
