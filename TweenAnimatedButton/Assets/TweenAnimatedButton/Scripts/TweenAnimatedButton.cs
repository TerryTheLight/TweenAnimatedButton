using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

/// <summary>
/// Custom Button which are animated when onClick
/// </summary>
public class TweenAnimatedButton : Button
{
    [SerializeField] private bool _disableUntilTweenFin = false;

    private Vector3 scaleUpSize = new Vector3(1.03f, 1.03f, 1.03f);

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!IsActive() || !IsInteractable())
            return;

        //TODO: Find ways to block raycast before the tween is complete

        //Run the tween animation first before running the real onClick
        LeanTween.scale(this.gameObject, scaleUpSize, 0.3f).setEaseShake().setOnComplete(OnCompleteClickAnimation);
    }

    private void OnCompleteClickAnimation()
    {
        UISystemProfilerApi.AddMarker("Button.onClick", this);
        base.onClick?.Invoke();
    }
}
