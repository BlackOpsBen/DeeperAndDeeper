using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeOption[] upgradeOptions;

    private void Awake()
    {
        foreach (UpgradeOption upgradeOption in upgradeOptions)
        {
            upgradeOption.displayName = upgradeOption.baseName + " " + upgradeOption.currentMultiplier.ToString();
        }
    }

    public void PerformUpgrade(int index)
    {
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
    [SerializeField] public string tooltip;
    [HideInInspector] public string displayName;
    [SerializeField] public Sprite icon;
    [SerializeField] public int dataCost;
    [SerializeField] public int costIncrease = 100;
    [SerializeField] public float costIncreaseMultipier = 1.1f;
    [SerializeField] public int currentMultiplier = 1;

    public void Advance()
    {
        currentMultiplier++;
        dataCost += costIncrease;
        costIncrease = Mathf.RoundToInt(costIncrease * costIncreaseMultipier);
        displayName = baseName + " " + currentMultiplier.ToString();
    }
}
