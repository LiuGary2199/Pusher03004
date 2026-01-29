Shader "iMoeGirl/Blinn-Phone" 
{
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Diffuse("Diffuse Color", Color) = (1,1,1,1)
        _Specular("Specular Color", Color) = (1,1,1,1)
        _Gloss("Gloss", Range(10, 200)) = 20
    }

    SubShader{
        Pass{
            Tags { "LightMode" = "ForwardBase" }

            CGPROGRAM
            #include "Lighting.cginc"
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Diffuse;
            fixed4 _Specular;
            float _Gloss;

            struct a2v {
                float3 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal: NORMAL;
            };

            struct v2f {
                float4 svPos: SV_POSITION;      // 这个是必须的，否则显示不出来
                float2 uv : TEXCOORD0;
                fixed3 normalizedWorldNormal : COLOR;
                float3 worldPos: TEXCOORD1;     // 顶点世界坐标
            };

            v2f vert(a2v v) 
            {
                v2f f;

                // 将模型空间的顶点坐标转换到裁剪空间
                f.svPos = UnityObjectToClipPos(v.vertex);
                f.uv = TRANSFORM_TEX(v.uv, _MainTex);
                // 将模型空间的法线转换到世界空间，然后标准化，
                //（转换到世界空间是为了后面和灯光做计算）
                f.normalizedWorldNormal = normalize(UnityObjectToWorldNormal(v.normal));

                return f;
            }

            fixed4 frag(v2f f) : SV_TARGET {
                fixed4 col = tex2D(_MainTex, f.uv); 
                // 下面先计算漫反射
                // 取得灯光方向，然后标准化
                float3 normalizedLightDir = normalize(_WorldSpaceLightPos0.xyz);
                fixed dotValue = dot(normalizedLightDir, f.normalizedWorldNormal) * 0.5 + 0.5;
                fixed3 diffuse = _LightColor0.rgb * col * _Diffuse* dotValue;

                // 再计算高光反射
                fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - f.worldPos);
                fixed3 halfDir = normalize(viewDir + normalizedLightDir);

                float specularValue = pow(max(dot(f.normalizedWorldNormal, halfDir), 0), _Gloss);
                fixed3 specular = _LightColor0.rgb * _Specular * specularValue;
                
                // 取得环境光
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb;

                // 最终颜色
                fixed3 color = specular + diffuse + ambient;

                return fixed4(color, 1);

            }

            ENDCG
        }
    }

    Fallback "VertexLit"
}
