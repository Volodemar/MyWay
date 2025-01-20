using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управление уровнем Game
/// </summary>	
public class GameLevelController : LevelController
{
	/// <summary>
	/// Инициализируем уровень
	/// </summary>
	public override void OnLevelInit()
	{
		base.OnLevelInit();

		UIManager.Instance.GetWindow<UIGameWindow>().Show();
	}
}
