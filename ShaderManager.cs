using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShaderManager : MonoBehaviour {

	public ShaderVariantCollection shaderVariantCollection;
	public Shader standardSetup;
	public Shader hiddenVertex;
	public Shader customDouble;
	public Shader atsRoad;
	public Shader bloodyDoor;
	public Shader standardDoubleFaced;
	public Shader bumbedSpecular;
	public Shader bumbedSpecularSmooth;
	public Shader tonLit;
	public Shader transparentBumbed;
	public Shader hiddenWaving;
	public Shader standard;


	void Start () {

		Debug.Log (shaderVariantCollection.variantCount);

		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ShadowCaster, "SHADOWS_DEPTH"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "DIRECTIONAL", "SHADOWS_SCREEN"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardBase, "DIRECTIONAL", "SHADOWS_SCREEN", "VERTEXLIGHT_ON"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardBase, "DIRECTIONAL", "SHADOWS_SCREEN","_EMISSION", "_SPECGLOSSMAP"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardBase, "DIRECTIONAL", "VERTEXLIGHT_ON","_EMISSION", "_SPECGLOSSMAP"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardBase, "DIRECTIONAL", "SHADOWS_SCREEN", "VERTEXLIGHT_ON", "_EMISSION", "_SPECGLOSSMAP"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardBase, "DIRECTIONAL", "SHADOWS_SCREEN", "_NORMALMAP", "_SPECGLOSSMAP"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardBase, "DIRECTIONAL", "SHADOWS_SCREEN", "VERTEXLIGHT_ON", "_NORMALMAP", "_SPECGLOSSMAP"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardBase, "DIRECTIONAL", "SHADOWS_SCREEN", "_EMISSION", "_NORMALMAP", "_SPECGLOSSMAP"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardBase, "DIRECTIONAL", "SHADOWS_SCREEN", "VERTEXLIGHT_ON " ,"_EMISSION", "_NORMALMAP", "_SPECGLOSSMAP"));

		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT_COOKIE"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "DIRECTIONAL_COOKIE"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "SHADOWS_DEPTH", "SPOT"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "DIRECTIONAL_COOKIE", "SHADOWS_SCREEN"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT_COOKIE", "SHADOWS_CUBE"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "SHADOWS_DEPTH", "SHADOWS_SOFT", "SPOT"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT", "SHADOWS_CUBE", "SHADOWS_SOFT"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT_COOKIE", "SHADOWS_CUBE", "SHADOWS_SOFT"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT", "_NORMALMAP", "_SPECGLOSSMAP"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "SPOT", "_NORMALMAP", "_SPECGLOSSMAP"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT_COOKIE", "_NORMALMAP", "_SPECGLOSSMAP"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "DIRECTIONAL_COOKIE", "_NORMALMAP", "_SPECGLOSSMAP")); 
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "SHADOWS_DEPTH", "SPOT", "_NORMALMAP", "_SPECGLOSSMAP"));  
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "DIRECTIONAL", "SHADOWS_SCREEN", "_NORMALMAP", "_SPECGLOSSMAP")); 
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "DIRECTIONAL_COOKIE", "SHADOWS_SCREEN", "_NORMALMAP", "_SPECGLOSSMAP")); 
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT", "SHADOWS_CUBE", "_NORMALMAP", "_SPECGLOSSMAP")); 
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT_COOKIE", "SHADOWS_CUBE", "_NORMALMAP", "_SPECGLOSSMAP")); 
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "SHADOWS_DEPTH", "SHADOWS_SOFT", "SPOT ", "_NORMALMAP", "_SPECGLOSSMAP"));  
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT", "SHADOWS_CUBE", "SHADOWS_SOFT ", "_NORMALMAP", "_SPECGLOSSMAP"));  
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT_COOKIE", "SHADOWS_CUBE", "SHADOWS_SOFT ", "_NORMALMAP", "_SPECGLOSSMAP"));   
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardAdd, "POINT", "_NORMALMAP", "_SPECGLOSSMAP", "_PARALLAXMAP","_DETAIL_MULX2"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standardSetup, PassType.ForwardBase, "DIRECTIONAL", "_EMISSION", "_NORMALMAP"));

		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standard, PassType.ForwardAdd, "SPOT", "_NORMALMAP", "_DETAIL_MULX2"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standard, PassType.ForwardAdd, "SPOT", "_NORMALMAP", "_METALLICGLOSSMAP"));
		shaderVariantCollection.Add (new ShaderVariantCollection.ShaderVariant (standard, PassType.ForwardAdd, "SPOT", "_NORMALMAP", "_PARALLAXMAP"));

		Debug.Log (shaderVariantCollection.variantCount);

	}
	

}
