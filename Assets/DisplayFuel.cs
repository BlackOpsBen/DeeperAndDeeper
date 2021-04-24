using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFuel : MonoBehaviour
{
    [SerializeField] private float widthPerFuelChunk = 150f;
    [SerializeField] private float fuelChunk = 10f;
    [SerializeField] private float padding = 10f;

    [SerializeField] private FuelManager fuelManager;

    [SerializeField] private RectTransform container;
    [SerializeField] private RectTransform fill;

    private void Update()
    {
        float containerWidth = (fuelManager.GetCapacity() / fuelChunk) * widthPerFuelChunk;
        container.sizeDelta = new Vector2(containerWidth, container.sizeDelta.y);

        float fillWidth = (fuelManager.GetFuel() / fuelChunk) * widthPerFuelChunk;
        fillWidth = Mathf.Clamp(fillWidth, 0f, containerWidth - padding * 2);
        fill.sizeDelta = new Vector2(fillWidth, fill.sizeDelta.y);
    }
}
