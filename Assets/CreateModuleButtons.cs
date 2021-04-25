using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateModuleButtons : MonoBehaviour
{
    [SerializeField] GameObject moduleBuyButton;
    [SerializeField] ShipManager shipManager;
    //[SerializeField] FuelManager fuelManager;
    [SerializeField] PurchaseManager purchaseManager;
    [SerializeField] Sprite refuelIcon;
    [SerializeField] int refuelCost = 300;
    [SerializeField] Color refuelButtonColor = Color.red;
    [SerializeField] RectTransform parentPanel;

    [SerializeField] private float xMargin = 10f;
    [SerializeField] private float yMargin = 10f;
    [SerializeField] private float spacing = 10f;

    private List<GameObject> buttons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shipManager.GetModuleOptions().Length; i++)
        {
            GameObject button = Instantiate(moduleBuyButton, parentPanel);
            buttons.Add(button);

            SetOnClick(button, i);
            SetMouseEvents(button, i);
            SetUI(button, i);
        }

        CreateRefuelButton();
    }

    private void CreateRefuelButton()
    {
        GameObject button = Instantiate(moduleBuyButton, parentPanel);
        buttons.Add(button);

        SetOnClick(button);
        SetMouseEvents(button);
        SetUI(button);

        Button btnComp = button.GetComponent<Button>();
        btnComp.image.color = refuelButtonColor;
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < buttons.Count; i++)
        {
            RectTransform rect = buttons[i].GetComponent<RectTransform>();
            float yOffset = yMargin + (rect.rect.height * i) + (spacing * i);
            rect.SetPositionAndRotation(new Vector3(xMargin, yOffset, 0f), Quaternion.identity);
            //rect.rect.Set(xMargin, yOffset, rect.rect.width, rect.rect.height);
        }*/
    }

    private void SetOnClick(GameObject button, int index)
    {
        Button btnComp = button.GetComponent<Button>();
        btnComp.onClick.AddListener(() => purchaseManager.AttemptBuyModule(index));
    }

    private void SetOnClick(GameObject button)
    {
        Button btnComp = button.GetComponent<Button>();
        btnComp.onClick.AddListener(() => purchaseManager.AttemptBuyFuel(refuelCost));
    }

    private void SetMouseEvents(GameObject button, int index)
    {
        MouseEventToolTips handler = button.GetComponent<MouseEventToolTips>();
        string foundText = shipManager.GetModuleOptions()[index].tooltip;
        handler.SetTooltipText(foundText);
    }

    private void SetMouseEvents(GameObject button)
    {
        MouseEventToolTips handler = button.GetComponent<MouseEventToolTips>();
        handler.SetTooltipText("Transmute Gold into Fuel to refill all Fuel Tanks.");
    }

    private void SetUI(GameObject button, int index)
    {
        DisplayButton displayButton = button.GetComponent<DisplayButton>();
        ModuleOption modOption = shipManager.GetModuleOptions()[index];
        displayButton.InitializeButton(modOption.name, modOption.icon, modOption.goldCost);
    }

    private void SetUI(GameObject button)
    {
        DisplayButton displayButton = button.GetComponent<DisplayButton>();
        displayButton.InitializeButton("Refuel", refuelIcon, refuelCost);
    }
}
