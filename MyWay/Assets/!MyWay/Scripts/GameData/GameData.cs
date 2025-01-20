using UnityEngine;

/// <summary>
/// Дата игры, минимальная реализация
/// </summary>	
public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

	public PlayerData PlayerData = new PlayerData();

	private void Awake()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(this.gameObject);

			PlayerData.Init();

			Instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	public void Save()
	{
		PlayerData.Save();
	}

	public void Load()
	{
		PlayerData.Load();
	}

	public void NewGame()
	{
		PlayerData.NewGame();

		Save();
	}
}
