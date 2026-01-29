Shader "MyShader/Diamond"
{
    Properties
    {
        _Color("Color",Color)=(1,1,1,1)
        _ReflectionStrength("Reflection Strength",Range(0.0,2.0))=1.0
        _EnvironmentLight ("Environment Light", Range(0.0,2.0)) = 1.0
        _Emission ("Emission", Range(0.0,2.0)) = 0.0
        [NoScaleOffset] _RefractTex ("Refraction Texture", Cube) = "" {}
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }
        LOD 100

        Pass
        {
            Cull  Front
            ZWrite Off 

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
                float4 pos:SV_POSITION ;
                float3 uv:TEXCOORD0  ; 
            };

            fixed4 _Color;
            samplerCUBE _RefractTex;
            half _EnvironmentLight;
            half _Emission;

            v2f vert ( appdata_base  v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                float3 viewDir=normalize(ObjSpaceViewDir(v.vertex));
                o.uv = -reflect(viewDir,v.normal);
                o.uv=mul(unity_ObjectToWorld,float4(o.uv,0));
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                half3 refraction=texCUBE(_RefractTex,i.uv).rgb*_Color.rgb;
                half4 reflection=UNITY_SAMPLE_TEXCUBE(unity_SpecCube0,i.uv);
                reflection.rgb=DecodeHDR(reflection,unity_SpecCube0_HDR);
                half3 multiplier=reflection.rgb*_EnvironmentLight+_Emission;
                return half4(refraction.rgb*multiplier.rgb,1.0f);
            }
            ENDCG
        }

        Pass
        {
            ZWrite On
            Blend One One

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
                float4 pos:SV_POSITION ;
                float3 uv:TEXCOORD0  ; 
                half fresnel:TEXCOORD1  ;
            };

            fixed4 _Color;
            samplerCUBE _RefractTex;
            half _ReflectionStrength;
            half _EnvironmentLight;
            half _Emission;

            v2f vert ( appdata_base  v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                float3 viewDir=normalize(ObjSpaceViewDir(v.vertex));
                o.uv = -reflect(viewDir,v.normal);
                o.uv=mul(unity_ObjectToWorld,float4(o.uv,0));
                o.fresnel=1-saturate(dot(v.normal,viewDir));
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
               /* unity_SpecCube0保存了环境的立体贴图（天空盒和反射探针形成的立体贴图）
                UNITY_SAMPLE_TEXCUBE 用于采样立体贴图
                DecodeHDR将高动态贴图转为正常RGB，如果导入的不是HDR贴图，就没有变化*/
                
                half3 refraction=texCUBE(_RefractTex,i.uv).rgb*_Color.rgb;
                half4 reflection=UNITY_SAMPLE_TEXCUBE(unity_SpecCube0,i.uv);
                reflection.rgb=DecodeHDR(reflection,unity_SpecCube0_HDR);
                half3 reflection2=reflection*_ReflectionStrength*i.fresnel;
                half3 multiplier=reflection.rgb*_EnvironmentLight+_Emission;
                return half4(reflection2+refraction.rgb*multiplier.rgb,1.0f);
            }
            ENDCG 
        }

        UsePass "VertexLit/SHADOWCASTER"
    }
}