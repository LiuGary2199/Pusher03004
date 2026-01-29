Shader "JJM_PixelsText_CirclePixels"
{
    Properties
    {
        _MainTex("MainTex", 2D) = "white" {}
        _Tiling("Pixel Density (Tiling)", Float) = 10 // 像素密度（值越大圆形越多）
        _Color("Color ", Color) = (1,1,1,1)
        _TextureSample1("Texture Sample 1", 2D) = "white" {}
        _Emission("Emission", Float) = 2
        _Speed("Animation Speed", Float) = 0.06
        _Scale("Noise Scale", Float) = 0.35
        _CircleSmooth("Circle Edge Smooth", Range(0.01, 0.5)) = 0.1 // 圆形边缘平滑度
        [HideInInspector] _texcoord( "", 2D ) = "white" {}
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGINCLUDE
        #pragma target 3.0
        ENDCG
        Blend OneMinusDstColor One, One One
        BlendOp Max, Add
        AlphaToMask Off
        Cull Back
        ColorMask RGBA
        ZWrite On
        ZTest LEqual
        Offset 0 , 0
        
        Pass
        {
            Name "Unlit"
            Tags { "LightMode"="ForwardBase" }
            CGPROGRAM

            #ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
            #define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
            #endif
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "UnityShaderVariables.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float4 ase_texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
            };

            // 声明属性
            uniform float4 _Color;
            uniform sampler2D _MainTex;
            uniform float4 _MainTex_ST;
            uniform sampler2D _TextureSample1;
            uniform float _Tiling;
            uniform float _Scale;
            uniform float _Speed;
            uniform float _Emission;
            uniform float _CircleSmooth; // 圆形边缘平滑度

            // 柏林噪声函数（保留原逻辑）
            float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
            float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
            float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
            float snoise( float2 v )
            {
                const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
                float2 i = floor( v + dot( v, C.yy ) );
                float2 x0 = v - i + dot( i, C.xx );
                float2 i1;
                i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
                float4 x12 = x0.xyxy + C.xxzz;
                x12.xy -= i1;
                i = mod2D289( i );
                float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
                float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
                m = m * m;
                m = m * m;
                float3 x = 2.0 * frac( p * C.www ) - 1.0;
                float3 h = abs( x ) - 0.5;
                float3 ox = floor( x + 0.5 );
                float3 a0 = x - ox;
                m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
                float3 g;
                g.x = a0.x * x0.x + h.x * x0.y;
                g.yz = a0.yz * x12.xz + h.yz * x12.yw;
                return 130.0 * dot( m, g );
            }
            
            v2f vert ( appdata v )
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                o.uv = TRANSFORM_TEX(v.ase_texcoord.xy, _MainTex);
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }
            
            fixed4 frag (v2f i ) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(i);
                UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

                // ========== 核心修改：把方形像素改成圆形像素 ==========
                // 1. 像素化UV（拆分“方格坐标”和“方格内的局部坐标”）
                float2 pixelGridUV = floor(i.uv * _Tiling); // 方格坐标（整数，每个方格一个值）
                float2 localUV = frac(i.uv * _Tiling) - 0.5; // 方格内局部坐标（-0.5~0.5，中心为0）
                
                // 2. 计算方格内的圆形距离场（核心：从方形变圆形）
                float circleDistance = length(localUV); // 局部坐标到方格中心的距离（圆形）
                float circleMask = smoothstep(0.5, 0.5 - _CircleSmooth, circleDistance); // 圆形蒙版
                
                // 3. 原噪波逻辑（基于方格坐标，保证每个圆形噪点的动态一致）
                float2 noiseUV = (pixelGridUV / _Tiling) * _Scale + _Time.y * _Speed;
                float noiseValue = snoise(noiseUV * 3.41);
                noiseValue = noiseValue * 0.5 + 0.5; // 归一化到0~1
                
                // 4. 纹理采样与混合（结合圆形蒙版）
                float4 mainTexColor = tex2D(_MainTex, i.uv);
                float4 sample1Color = tex2D(_TextureSample1, float2(noiseValue, noiseValue));
                float4 lerpResult = lerp(float4(0,0,0,1), mainTexColor, sample1Color.r);
                
                // 5. 最终颜色（乘以圆形蒙版，只保留圆形区域）
                fixed4 finalColor = _Color * lerpResult * _Emission * circleMask;

                return finalColor;
            }
            ENDCG
        }
    }
}