using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayLabels : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceValue;
    [SerializeField] TextMeshProUGUI speedValue;
    [SerializeField] TextMeshProUGUI dataLabel;
    [SerializeField] TextMeshProUGUI goldLabel;

    [SerializeField] ResourceManager resourceManager;
    [SerializeField] CalculateDistance calculateDistance;

    // Update is called once per frame
    void Update()
    {
        distanceValue.text = calculateDistance.GetDistanceString();
        speedValue.text = calculateDistance.GetSpeedString();

        string dataText = resourceManager.GetData().ToString();
        string goldText = resourceManager.GetGold().ToString();
        dataLabel.text = dataText;
        goldLabel.text = goldText;
    }
}
