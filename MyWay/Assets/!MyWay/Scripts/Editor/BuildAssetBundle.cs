using System;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Создание AssedBundle для выгрузки в Clouds
/// </summary>	
public class BuildAssetBundle : MonoBehaviour
{
	[MenuItem("Assets/Create Assets Bundles")]
	private static void BuidlAllAssetsBundle()
	{
		string path = Application.dataPath + "/../AssetsBundles";

		try
		{
			BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
		}
		catch(Exception e)
		{
			Debug.LogWarning(e);
		}
	}
}
