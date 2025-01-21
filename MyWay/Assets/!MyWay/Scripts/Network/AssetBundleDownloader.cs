using System.Collections;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Загружает AssetBundle из DropBox
/// </summary>	
public class AssetBundleDownloader : MonoBehaviour
{
    public string url = "ASSET_BUNDLE_FOLDER_URL_HERE";

    private string downloadFolder = "DownloadBundles";

    public IEnumerator DownloadAssetBundle()
    {
        string newUrl = url.Split('&')[0] + "&dl=1";

        using (UnityWebRequest www = UnityWebRequest.Get(newUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: скачивание архива не удалось: " + www.error);
                yield break;
            }

            byte[] bytes = www.downloadHandler.data;

            // Создаем директорию для распаковки
            string unpackPath = Path.Combine(Application.persistentDataPath, downloadFolder);

            // Создаем директорию, если она не существует
            if (!Directory.Exists(unpackPath))
            {
                Directory.CreateDirectory(unpackPath);
            }
            else
            {
                // Очистка от старых данных
                Directory.Delete(unpackPath, true);
                Directory.CreateDirectory(unpackPath);
            }

            // Сохраняем байтовый массив в файл
            string zipPath = Path.Combine(unpackPath, "AssetsBundles.zip");
            File.WriteAllBytes(zipPath, bytes);

            // Распаковываем архив
            using (ZipArchive zipArchive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in zipArchive.Entries)
                {
                    string entryPath = Path.Combine(unpackPath, entry.FullName);

                    // Т.к. в архиве присутствует ненужная директория
                    if (entryPath == "/")
                        continue;

                    // Распаковываем файл
                    entry.ExtractToFile(entryPath, true);
				}
            }

			//Удаляем файл архива после распаковки
			File.Delete(zipPath);
		}
    }
}
