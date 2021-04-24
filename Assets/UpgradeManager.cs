using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeOption[] upgradeOptions;

    public void PerformUpgrade(int index)
    {
        Debug.LogWarning("Upgrading " + upgradeOptions[index].name);
    }

    public UpgradeOption[] GetUpgradeOptions()
    {
        return upgradeOptions;
    }
}

[System.Serializable]
public class UpgradeOption
{
    [SerializeField] public string name;
    [SerializeField] public Sprite icon;
    [SerializeField] public int dataCost;
}
