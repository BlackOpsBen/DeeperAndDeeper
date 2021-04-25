using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private DisplayShip previewShip;

    [SerializeField] private ModuleOption[] moduleOptions;

    public void AddModule(int index)
    {
        moduleOptions[index].quantity++;
        previewShip.AddModule(moduleOptions[index].moduleObject);
    }

    public ModuleOption[] GetModuleOptions()
    {
        return moduleOptions;
    }
}

[System.Serializable]
public class ModuleOption
{
    [SerializeField] public string name;
    [SerializeField] public string tooltip;
    [SerializeField] public Sprite icon;
    [SerializeField] public GameObject moduleObject;
    [SerializeField] public int goldCost;
    [HideInInspector] public int quantity = 0;
}
