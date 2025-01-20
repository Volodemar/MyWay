using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Менеджер игры (входная точка любой сцены)
/// </summary>	
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string SceneName => SceneManager.GetActiveScene().name;

	private void Awake()
	{
		Instance = this;

		if (LoadingHelper.IsLoadingInit == false)
		{
			SceneManager.LoadScene("Preload");
		}
	}

	private void Start()
	{
		if (LoadingHelper.IsLoadingInit == true)
		{
			LevelController.Instance?.OnLevelInit();
		}
	}
}
