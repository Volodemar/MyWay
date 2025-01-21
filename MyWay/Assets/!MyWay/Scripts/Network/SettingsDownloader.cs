using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Загружает Settings.json из DropBox
/// </summary>	
public class SettingsDownloader : MonoBehaviour
{
    public string url = "ASSET_JSON_FILE_URL_HERE";

    public IEnumerator DownloadSettings()
    {
        string newUrl = url.Split('&')[0] + "&dl=1";

        using (UnityWebRequest www = UnityWebRequest.Get(newUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: скачивание json не удалось: " + www.error);
                yield break;
            }

            byte[] bytes = www.downloadHandler.data;

            string json = System.Text.Encoding.UTF8.GetString(bytes);

            try
            {
                Debug.Log("Получен JSON: " + json );

                var gameData = GameData.Instance;

			    SettingsData loadSettingsData = JsonUtility.FromJson<SettingsData>(json);
				gameData.SettingsData = loadSettingsData;
			}
            catch (Exception e)
            {
                Debug.Log("Error: Сериализация Settings.json " + e.Message);
            }
        }
    }
}
