using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Анимация для надписи загрузки.
/// </summary>	
public class TweenAminationLoading : MonoBehaviour
{
	private void Start()
    {
        this.transform.GetComponent<RectTransform>().DOScale(1.1f, 0.5f).SetEase(Ease.InCubic).SetLoops(-1, LoopType.Yoyo);
    }
}
