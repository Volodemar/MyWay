using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SavePlayerData 
{
	public int StartingNumber	= 0;
}

/// <summary>
/// Дата игрока (хранит значения между запусками)
/// </summary>	
public class PlayerData
{
    public int StartingNumber { get; private set; } = 0;

	private string _path;

	#region Методы данных
	public void SetStartingNumber(int value) => StartingNumber = value;

	public void ModifyStartingNumber(int value)
	{
		StartingNumber = Mathf.Max(0, StartingNumber + value);
	}
	#endregion

	#region Инициализация, сохранение и загрузка
	public void Init()
	{
		_path = Application.persistentDataPath + "/PlayerData.json";
	}

	/// <summary>
	/// Создание новой игры
	/// </summary>
    public void NewGame()
	{
		StartingNumber = GameData.Instance.SettingsData.StartingNumber;
	}

	public void Save()
	{
		SavePlayerData save = new SavePlayerData();
		save.StartingNumber = StartingNumber;

        string json = JsonUtility.ToJson(save);
        File.WriteAllText(_path, json);
	}

	public void Load()
	{
		if(File.Exists(_path))
		{ 
			string json = File.ReadAllText(_path);
			SavePlayerData load = JsonUtility.FromJson<SavePlayerData>(json);
			StartingNumber	= load.StartingNumber;
		}
		else
		{
			NewGame();
		}
	}
	#endregion
}
