using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Менеджер интерфейса
/// </summary>	
public class UIManager : MonoBehaviour
{
    [SerializeField] private List<UIWindow> windows = new List<UIWindow>();

    public static UIManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

    public T GetWindow<T>() where T : UIWindow
    {
        var windowType = typeof(T);

        foreach (UIWindow window in windows)
        {
            if (window.GetType() == windowType)
            {
                return (T)window;
            }
        }

        return null;
    }
}
