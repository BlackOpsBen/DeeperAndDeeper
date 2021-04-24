using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private DisplayShip previewShip;

    [SerializeField] private ModuleOption[] moduleOptions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    [SerializeField] public Sprite icon;
    [SerializeField] public GameObject moduleObject;
    [SerializeField] public int goldCost;
    [HideInInspector] public int quantity = 0;
}
