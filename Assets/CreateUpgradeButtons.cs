using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateUpgradeButtons : MonoBehaviour
{
    [SerializeField] GameObject upgradeBuyButton;

    [SerializeField] UpgradeManager upgradeManager;

    [SerializeField] PurchaseManager purchaseManager;

    [SerializeField] RectTransform parentPanel;

    [SerializeField] Sprite dataCostIcon;
    [SerializeField] Color dataCostIconColor;

    [SerializeField] private float xMargin = 10f;
    [SerializeField] private float yMargin = 10f;
    [SerializeField] private float spacing = 10f;

    private List<GameObject> buttons = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < upgradeManager.GetUpgradeOptions().Length; i++)
        {
            GameObject button = Instantiate(upgradeBuyButton, parentPanel);
            buttons.Add(button);

            SetOnClick(button, i);
            SetMouseEvents(button, i);
            SetUI(button, i);
        }
    }

    /*private void Update()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            SetUI(buttons[i], i);
        }
    }*/

    private void SetOnClick(GameObject button, int index)
    {
        Button btnComp = button.GetComponent<Button>();
        btnComp.onClick.AddListener(() => purchaseManager.AttemptBuyUpgrade(index));
    }

    private void SetMouseEvents(GameObject button, int index)
    {
        MouseEventToolTips handler = button.GetComponent<MouseEventToolTips>();
        string foundText = upgradeManager.GetUpgradeOptions()[index].tooltip;
        handler.SetTooltipText(foundText);
    }

    private void SetUI(GameObject button, int index)
    {
        DisplayButton displayButton = button.GetComponent<DisplayButton>();
        UpgradeOption upgradeOption = upgradeManager.GetUpgradeOptions()[index];
        displayButton.InitializeButton(upgradeOption.displayName, upgradeOption.icon, upgradeOption.dataCost, dataCostIcon, dataCostIconColor);
    }

    public void UpdateButton(int index)
    {
        SetUI(buttons[index], index);
    }
}