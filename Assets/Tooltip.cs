using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    [SerializeField] GameObject textPanel;
    [SerializeField] TextMeshProUGUI textBox;

    bool isShowing = false;

    public void ShowToolTip(string text)
    {
        textBox.text = text;
        isShowing = true;
    }

    public void HideToolTip()
    {
        isShowing = false;
        textBox.text = "...";
    }

    private void Update()
    {
        textPanel.SetActive(isShowing);
    }
}
