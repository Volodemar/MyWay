using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Первичная загрузка
/// </summary>	
public class Preload : MonoBehaviour
{
	private IEnumerator Start()
	{
		LoadingHelper.IsLoadingInit = true;

		// Загрузка данных игры, если они есть
		GameData.Instance.Load();

		yield return new WaitForSeconds(3f);

		SceneManager.LoadScene("Game");
	}
}
