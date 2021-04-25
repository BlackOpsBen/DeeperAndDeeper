using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseEventToolTips : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string text = "...";

    private Tooltip tooltip;

    private void Start()
    {
        tooltip = FindObjectOfType<Tooltip>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowToolTip(text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideToolTip();
    }

    public void SetTooltipText(string tooltipText)
    {
        text = tooltipText;
    }
}
