Shader "Matej Vanco/RayMarcher/PC/RM Master_Example_PCVR_MusicReaction"
{

	//-----------The shader was generated by the RM_XConvertor - Please do not change any property nor location of the shader

	Properties
	{
			[NoScaleOffset]
			_MASrenderMainFilter("Render Filter [INTERNAL USE]",2D) = "white"{}

			//----------RENDER SECTION-------------------------
			//---RENDER : Textures & Colors
			_MASrenderMainColor("Base Color", Color) = (1,1,1,1)
			_MASrenderMainEmission("Base Emission", Float) = 0
			_MASrenderSpecularA("Specular ValA", Float) = 0
			_MASrenderSpecularB("Specular ValB", Float) = 0
			_MASrenderSpecularIntens("Specular Intens", Float) = 0
			_MASrenderSecondColor("Secondary Color", Color) = (1,0.5,0,1)
			_MASrenderPrimaryTexture("Primary Texture",2D) = "white"{}
			_MASrenderPrimaryTextureTile("Texture Tilling",Float) = 1

			//---RENDER : Quality & Render Settings
			_MASrenderMaxDistance("Render Distance", Float) = 10
			[Toggle]_MASrenderQualitySetting("Simple Render", Int) = 0
			_MASrenderQuality("Render Quality",Range(0.5,0.0001)) = 0.005

			//---RENDER : Rendering Options [Fresnel, Toon Shading, Soft Outline, Global smoothness]
			_MASrenderFresnel("Fresnel Density", Float) = 1
			_MASrenderFresnelMultiplier("Fresnel Multiplier", Float) = 1

			_MASrenderToonThresh("Toon Threshold", Float) = 1
			_MASrenderToonDens("Toon Density", Float) = 1

			_MASfogDensity("Fog Density", Float) = 0
			_MASfogColor("Fog Color", Color) = (1,1,1,1)

			_MASrenderSmoothness("Global Smoothness", Float) = 0
			_MASrenderColorSmoothness("interFinalColor Smoothness", Float) = 0

			//----------SHADING SECTION-------------------------
			//---SHADING : Lighting
			_LIGHTintens("Light Intensity",Range(0,1)) = 0.5
			_LIGHTdirect("Light Direction",Vector) = (0,1,0,0)
			_LIGHTjitter("Light Smooth Jitter",Range(0.001,0.5)) = 0.001

			//---SHADING : Shadows
			[Toggle]_SHADEenabled("Shadow Enabled",Int) = 1
			_SHADEdistance("Shadow Distance", Vector) = (0.02,10,0,0)
			_SHADEintens("Shadow Intensity", Float) = 1
			[Toggle]_SHADEsoft("Shadow Soft", Int) = 1
			_SHADEsoftness("Shadow Softness", Range(1,20)) = 4

			//---SHADING : Reflection
			[Toggle]_REFLECTenabled("Reflection Enabled",Int) = 1
			_REFLECTintensity("Reflection Intensity",Float) = 0.6
			[Toggle]_REFLECTcubemapEnabled("Enable Skybox Reflection",Int) = 1
			_REFLECTcubemap("Skybox Reflection", CUBE) = "" {}
			[Toggle]_REFLECTphysX("Reflection Physically Based",Int) = 0
			_REFLECTphysXemiss("Physical Reflection Emission",Range(-1,1)) = 0
			_REFLECTphysXintens("Physical Reflection Intensity",Range(0,1)) = 1

			_REFLECTphysXSampleCount("Physical Reflection - Samples", Int) = 1

			//----------GLOBAL OPERATIONS SECTION-------------------------
			//---GLOBAL OPERATIONS : Loop
			[Toggle]_OPloopEnabled("Loop Operation", Int) = 0
			_OPloopTilling("Loop Tilling",Vector) = (10,10,10,10)
			[Toggle]_OPloopTwoDimens("Loop Two Dimensional",Int) = 0

			//---Internal macros & info for developer----
			//-Master/Major functions & variables starting with MAS
			//-Macro/Define functions & variables starting with MA
			//-Generator functions & variables starting with GEN
			//-Operation functions & variables starting with OP

			//-Other optional & specific macros: LIGHT[Shading:lighting], SHADE[Shading:shadows], REFLECT[Shading:reflections]
			//-All internal shader variables starting with inter
	}
	SubShader
	{


		Pass
		{
			CGPROGRAM

				#pragma vertex MAS_Vertex
				#pragma fragment MAS_Fragment
				#pragma target 5.0
				#include "UnityCG.cginc"

				
				#define RENDER_FLAT

				#include "Includes\PC\Raymarch_Properties.cginc"

				#include "Includes\PC\Raymarch_VertVR.cginc"

				#include "Includes\PC\Raymarch_Operators.cginc"

				#include "ShapeSources\Raymarch_ShapesSource_Example_PCVR_MusicReaction.cginc"

				#include "Includes\PC\Raymarch_FractsSource.cginc"

				#include "ObjectBuffers\Raymarch_ObjectBuffer_Example_PCVR_MusicReaction.cginc"	

				#include "Includes\PC\Raymarch_Shading.cginc"

				#include "Includes\PC\Raymarch_CoreVR.cginc"

				#include "Includes\PC\Raymarch_Reflections.cginc"

				#include "Includes\PC\Raymarch_FragVR.cginc"

			ENDCG
		}
	}
}
