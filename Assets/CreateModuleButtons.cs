using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateModuleButtons : MonoBehaviour
{
    [SerializeField] GameObject moduleBuyButton;
    [SerializeField] ShipManager shipManager;

    [SerializeField] private float xMargin = 10f;
    [SerializeField] private float yMargin = 10f;
    [SerializeField] private float spacing = 10f;

    private List<GameObject> buttons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shipManager.GetModuleOptions().Length; i++)
        {
            GameObject button = Instantiate(moduleBuyButton, transform);
            buttons.Add(button);

            SetOnClick(button, i);
            SetUI(button, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            RectTransform rect = buttons[i].GetComponent<RectTransform>();
            float yOffset = yMargin + rect.rect.height * i + spacing * i;
            rect.SetPositionAndRotation(new Vector3(xMargin, yOffset, 0f), Quaternion.identity);
        }
    }

    private void SetOnClick(GameObject button, int index)
    {
        Button btnComp = button.GetComponent<Button>();
        btnComp.onClick.AddListener(() => shipManager.AddModule(index));
    }

    private void SetUI(GameObject button, int index)
    {
        DisplayButton displayButton = button.GetComponent<DisplayButton>();
        ModuleOption modOption = shipManager.GetModuleOptions()[index];
        displayButton.InitializeButton(modOption.name, modOption.icon, modOption.goldCost);
    }
}
