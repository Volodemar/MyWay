using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управление уровнем Game
/// </summary>	
public class GameLevelController : LevelController
{
	public AssetBundleLoader assetBundleLoader;

	// Т.к. по ТЗ надо заного скачать данные
	public AssetBundleDownloader assetBundleDownloader;
	public SettingsDownloader settingsDownloader;

	/// <summary>
	/// Инициализируем уровень
	/// </summary>
	public override void OnLevelInit()
	{
		base.OnLevelInit();

		UIManager.Instance.GetWindow<UIGameWindow>().Show();
	}

	public IEnumerator UpdateContent(Action<Sprite> callback)
	{
		//TODO: У нас все кешировано после запуска приложения, но по ТЗ нужно по кнопке скачивать данные заного
		yield return StartCoroutine(assetBundleDownloader.DownloadAssetBundle());
		yield return StartCoroutine(settingsDownloader.DownloadSettings());

		yield return StartCoroutine(assetBundleLoader.LoadAssetBundleSprite("Lestat-256х256", (Sprite sprite) =>
		{
			var gameGata = GameData.Instance;

			gameGata.PlayerData.SetStartingNumber(gameGata.SettingsData.StartingNumber);

			callback(sprite);
		})); 
	}
}
