using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    private ResourceManager resourceManager;
    private ShipManager shipManager;
    private FuelManager fuelManager;

    private void Start()
    {
        resourceManager = GetComponent<ResourceManager>();
        shipManager = GetComponent<ShipManager>();
        fuelManager = GetComponent<FuelManager>();
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
}
