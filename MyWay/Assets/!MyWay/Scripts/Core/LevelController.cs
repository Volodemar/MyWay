using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управление уровнем
/// </summary>	
public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get; private set; }

	public AssetBundleLoader assetBundleLoader;

    private void Awake()
    {
        Instance = this;
    }

	/// <summary>
	/// Инициализируем уровень
	/// </summary>
	public virtual void OnLevelInit()
	{
	}
}
