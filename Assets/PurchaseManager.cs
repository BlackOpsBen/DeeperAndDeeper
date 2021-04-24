using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    private ResourceManager resourceManager;
    private ShipManager shipManager;
    private FuelManager fuelManager;
    private UpgradeManager upgradeManager;
    private CreateUpgradeButtons createUpgradeButtons;

    private void Start()
    {
        resourceManager = GetComponent<ResourceManager>();
        shipManager = GetComponent<ShipManager>();
        fuelManager = GetComponent<FuelManager>();
        upgradeManager = GetComponent<UpgradeManager>();
        createUpgradeButtons = FindObjectOfType<CreateUpgradeButtons>();
    }

    public void AttemptBuyModule(int index)
    {
        int price = shipManager.GetModuleOptions()[index].goldCost;
        if (resourceManager.GetGold() >= price)
        {
            // Successful purchase
            shipManager.AddModule(index);
            resourceManager.ModifyGold(-price);
        }
        else
        {
            // Insufficient Gold
            Debug.LogWarning("Not enough gold.");
        }
    }

    public void AttemptBuyFuel(int price)
    {
        if (resourceManager.GetGold() >= price)
        {
            // Successful purchase
            fuelManager.Refuel();
            resourceManager.ModifyGold(-price);
        }
        else
        {
            // Insufficient Gold
            Debug.LogWarning("Not enough gold.");
        }
    }

    public void AttemptBuyUpgrade(int index)
    {
        int price = upgradeManager.GetUpgradeOptions()[index].dataCost;
        if (resourceManager.GetData() >= price)
        {
            // Successful purchase
            upgradeManager.PerformUpgrade(index);
            resourceManager.ModifyData(-price);
            createUpgradeButtons.UpdateButton(index);
        }
        else
        {
            // Insufficient Gold
            Debug.LogWarning("Not enough data.");
        }
    }
}
