using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Окно игры
/// </summary>	
public class UIGameWindow : UIWindow
{
	[SerializeField] Button buttonUpdate;
    [SerializeField] Button buttonIncrement;

	GameLevelController _gameLevel;

	private void Start()
	{
		_gameLevel = LevelController.Instance as GameLevelController;
	}

	public void OnClickUpdateContent()
    {
		buttonUpdate.interactable = false;

		StartCoroutine(_gameLevel.assetBundleLoader.LoadAssetBundleSprite("Lestat-256х256", (Sprite sprite) =>
        {
            buttonIncrement.image.sprite = sprite;

			buttonUpdate.interactable = true;
        }));       
    }
}
