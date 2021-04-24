using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mainLabel;
    [SerializeField] Image mainIcon;
    [SerializeField] TextMeshProUGUI costLabel;
    [SerializeField] Image costIcon;

    public void InitializeButton(string mainText, Sprite mainImage, int cost, Sprite costImage)
    {
        mainLabel.text = mainText;
        mainIcon.sprite = mainImage;
        costLabel.text = cost.ToString();
        costIcon.sprite = costImage;
    }

    public void InitializeButton(string mainText, Sprite mainImage, int cost)
    {
        mainLabel.text = mainText;
        mainIcon.sprite = mainImage;
        costLabel.text = cost.ToString();
    }
}
