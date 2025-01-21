using System.IO;
using UnityEditor;
using UnityEngine;

public class SettingsMenu : EditorWindow
{
	[MenuItem("Project/Settings")]
	public static void OpenSettingsFile()
	{
		string path = Path.Combine("Assets/!MyWay/Settings", "MyWaySettings.asset");

		Selection.activeObject = AssetDatabase.LoadAssetAtPath<Object>(path);
	}
}