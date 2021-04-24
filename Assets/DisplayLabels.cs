using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayLabels : MonoBehaviour
{
    [SerializeField] string distancePrefix = "Distance: ";

    [SerializeField] TextMeshProUGUI distanceLabel;
    [SerializeField] TextMeshProUGUI resourceLabels;

    [SerializeField] ResourceManager resourceManager;
    [SerializeField] CalculateDistance calculateDistance;

    // Update is called once per frame
    void Update()
    {
        distanceLabel.text = distancePrefix + calculateDistance.GetDistance();
        string dataText = resourceManager.GetData().ToString();
        string oreText = resourceManager.GetGold().ToString();
        resourceLabels.text = dataText + "\n" + oreText;
    }
}
