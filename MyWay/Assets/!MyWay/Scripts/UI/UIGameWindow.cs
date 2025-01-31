using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Окно игры
/// </summary>	
public class UIGameWindow : UIWindow
{
	[SerializeField] TextMeshProUGUI textMessage;
	[SerializeField] Button buttonUpdate;
    [SerializeField] Button buttonIncrement;
	[SerializeField] TextMeshProUGUI textStartingNumber;

	GameLevelController _gameLevel;

	private void Start()
	{
		_gameLevel = LevelController.Instance as GameLevelController;

		textStartingNumber.text = GameData.Instance.PlayerData.StartingNumber.ToString();
	}

	public void OnClickUpdateContent()
    {
		buttonUpdate.interactable = false;
		buttonIncrement.interactable = false;

		StartCoroutine(_gameLevel.UpdateContent((Sprite sprite) => 
		{
			buttonIncrement.image.sprite = sprite;

			var gameGata = GameData.Instance;

			textMessage.text = gameGata.SettingsData.HelloyMessage;

			textStartingNumber.text = gameGata.PlayerData.StartingNumber.ToString();

			buttonUpdate.interactable = true;
			buttonIncrement.interactable = true;
		}));
    }

	public void OnClickIncrement()
    {
		var gameGata = GameData.Instance;

		gameGata.PlayerData.ModifyStartingNumber(+1);

		textStartingNumber.text = gameGata.PlayerData.StartingNumber.ToString();
	}
}
