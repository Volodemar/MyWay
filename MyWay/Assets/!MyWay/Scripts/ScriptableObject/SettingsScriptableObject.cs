using System;
using NaughtyAttributes;
using UnityEngine;
using System.IO;

[Serializable]
public class SettingsData
{
	[SerializeField] public int StartingNumber	= 0;
	[SerializeField] public string HelloyMessage = "";
}

/// <summary>
/// Конфиг приложения
/// </summary>	
[CreateAssetMenu(fileName = "MyWaySettings", menuName = "ScriptableObjects/MyWaySettings")]
public class SettingsScriptableObject : ScriptableObject
{
    public int StartingNumber = 0;

	[TextArea(5,10)]
	public string HelloyMessage = "";

	[Button("Create Settings file")]
	private void CreateSettingsFile()
	{
		string path = Application.dataPath + "/../Settings/Settings.json";

		try
		{
			SettingsData save = new SettingsData();
			save.StartingNumber = StartingNumber;
			save.HelloyMessage  = HelloyMessage;

			string json = JsonUtility.ToJson(save);
			File.WriteAllText(path, json);			
		}
		catch(Exception e)
		{
			Debug.LogWarning(e);
		}
	}
}
