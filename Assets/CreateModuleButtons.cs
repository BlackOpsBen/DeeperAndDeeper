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
            SetText(button, i);
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

    private void SetText(GameObject button, int index)
    {
        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Test " + index.ToString();
    }
}
