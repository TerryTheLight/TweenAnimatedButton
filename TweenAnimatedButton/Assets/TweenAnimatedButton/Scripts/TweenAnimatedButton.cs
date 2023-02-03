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
    [Tooltip("Activate a raycast blocker when animating so players could not double click a button")]
    [SerializeField] private bool _disableUntilTweenFin = true;
    private Vector3 scaleUpSize = new Vector3(1.03f, 1.03f, 1.03f);

    private bool isTweening = false;

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!IsActive() || !IsInteractable() || isTweening)
            return;

        if(_disableUntilTweenFin)
            isTweening = true;

        //Run the tween animation first before running the real onClick
        LeanTween.scale(this.gameObject, scaleUpSize, 0.3f).setEaseShake().setOnComplete(OnCompleteClickAnimation);
    }

    private void OnCompleteClickAnimation()
    {
        UISystemProfilerApi.AddMarker("Button.onClick", this);
        base.onClick?.Invoke();
        isTweening = false;
    }
}
