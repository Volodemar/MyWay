using TMPro;
using UnityEngine;
/// <summary>
/// Окно запуска приложения
/// </summary>	
public class UIPreloadWindow : UIWindow
{
    [SerializeField] private TextMeshProUGUI textLoadingLog;

    public void SetLoadingLogText(string message)
    {
        textLoadingLog.text = message;
    }
}
