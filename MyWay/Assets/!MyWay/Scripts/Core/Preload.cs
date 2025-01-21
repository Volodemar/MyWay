using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Первичная загрузка
/// </summary>	
public class Preload : MonoBehaviour
{
	[SerializeField] AssetBundleDownloader ABDownloader;
	[SerializeField] SettingsDownloader SettingsDownloader;

	private IEnumerator Start()
	{
		LoadingHelper.IsLoadingInit = true;

		var preloadWindow = UIManager.Instance.GetWindow<UIPreloadWindow>();

		preloadWindow.SetLoadingLogText("- скачивание бандлов -");

		yield return StartCoroutine(ABDownloader.DownloadAssetBundle());

		yield return new WaitForSeconds(1f);

		preloadWindow.SetLoadingLogText("- скачивание конфига -");

		yield return StartCoroutine(SettingsDownloader.DownloadSettings());

		yield return new WaitForSeconds(1f);

		preloadWindow.SetLoadingLogText("- загрузка сохранений -");

		GameData.Instance.Load();

		yield return new WaitForSeconds(1f);

		preloadWindow.SetLoadingLogText("- загрузка -");

		yield return new WaitForSeconds(1f);

		SceneManager.LoadScene("Game");
	}
}
