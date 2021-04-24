using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeOption[] upgradeOptions;

    private void Start()
    {
        foreach (UpgradeOption upgradeOption in upgradeOptions)
        {
            upgradeOption.displayName = upgradeOption.baseName + " " + upgradeOption.currentMultiplier.ToString();
        }
    }

    public void PerformUpgrade(int index)
    {
        Debug.LogWarning("Upgrading " + upgradeOptions[index].displayName);
        upgradeOptions[index].Advance();
    }

    public UpgradeOption[] GetUpgradeOptions()
    {
        return upgradeOptions;
    }

    public float GetUpgradeMultiplier(int upgradeIndex)
    {
        return upgradeOptions[upgradeIndex].currentMultiplier;
    }
}

[System.Serializable]
public class UpgradeOption
{
    [SerializeField] public string baseName;
    [HideInInspector] public string displayName;
    [SerializeField] public Sprite icon;
    [SerializeField] public int dataCost;
    [SerializeField] public float costIncrease = 100f;
    [SerializeField] public float costIncreaseMultipier = 1.1f;
    [SerializeField] public int currentMultiplier = 1;

    public void Advance()
    {
        currentMultiplier++;
        costIncrease *= costIncreaseMultipier;
        displayName = baseName + " " + currentMultiplier.ToString();
        Debug.LogWarning("Advanced to " + displayName);
    }
}
