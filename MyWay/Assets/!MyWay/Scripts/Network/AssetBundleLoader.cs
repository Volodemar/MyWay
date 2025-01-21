using System.Collections;
using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Загрузка ресурсов из Asset Bundle
/// </summary>	
public class AssetBundleLoader : MonoBehaviour
{
	private string downloadFolder = "DownloadBundles";

	public IEnumerator LoadAssetBundleSprite(string spriteName, Action<Sprite> callback)
	{
		string fileName = "sprites";

        // Получаем список файлов в папке
        string unpackPath = Path.Combine(Application.persistentDataPath, downloadFolder);
		string[] files = Directory.GetFiles(unpackPath);

        // Ищем файл с определенным именем
        foreach (string file in files)
        {
            if (Path.GetFileName(file) == fileName)
            {
				//Загружаем бандл из файла
				AssetBundle assetBundle = AssetBundle.LoadFromFile(file);

				if (assetBundle == null)
				{
					Debug.Log("Error: загрузка бандла не удалась");
					yield break;
				}

				// Получаем префаб из бандла
				Sprite sprite = assetBundle.LoadAsset<Sprite>(spriteName);

				if (sprite == null)
				{
					Debug.Log("Error: префаб не найден");
					yield break;
				}

				// Создаем инстанс префаба
				callback(sprite);

				// Удаляем бандл после использования
				assetBundle.Unload(false);

				// Выходим из цикла, поскольку мы нашли файл
				yield break;
            }
        } 
	}
}
