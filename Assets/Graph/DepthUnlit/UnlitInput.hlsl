#ifndef UNIVERSAL_UNLIT_INPUT_INCLUDED
#define UNIVERSAL_UNLIT_INPUT_INCLUDED

#include "SurfaceInput.hlsl"

CBUFFER_START(UnityPerMaterial)
float4 _MainTex_ST;
half _Cutoff;
half _Hit;
half _Freeze;
half _Glossiness;
half _Metallic;
float3 _HitColor;
float3 _FreezeColor;
float3 _DoubleColor;
CBUFFER_END

#endif