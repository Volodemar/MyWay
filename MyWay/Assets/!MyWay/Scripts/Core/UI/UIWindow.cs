using UnityEngine;

/// <summary>
/// Окно интерфейса
/// </summary>	
public class UIWindow : MonoBehaviour
{
	public virtual void Show()
	{
		this.gameObject.SetActive(true);
	}    

	public virtual void HIde()
	{
		this.gameObject.SetActive(false);
	}   
}
