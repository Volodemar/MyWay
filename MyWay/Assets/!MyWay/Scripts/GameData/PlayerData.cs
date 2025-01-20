using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SavePlayerData 
{
	[SerializeField] public int StartNumber	= 0;
}

/// <summary>
/// Дата игрока (хранит значения между запусками)
/// </summary>	
public class PlayerData
{
    public int StartNumber { get; private set; } = 0;

	private string _path;

	#region Методы данных
	public void SetStartNumber(int value) => StartNumber = value;

	public void ModifyStartNumber(int value)
	{
		StartNumber = Mathf.Max(0, StartNumber + value);
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
		StartNumber = 0;
	}

	public void Save()
	{
		SavePlayerData save = new SavePlayerData();
		save.StartNumber = StartNumber;

        string json = JsonUtility.ToJson(save);
        File.WriteAllText(_path, json);
	}

	public void Load()
	{
		if(File.Exists(_path))
		{ 
			string json = File.ReadAllText(_path);
			SavePlayerData load = JsonUtility.FromJson<SavePlayerData>(json);
			StartNumber	= load.StartNumber;
		}
		else
		{
			NewGame();
		}
	}
	#endregion
}
