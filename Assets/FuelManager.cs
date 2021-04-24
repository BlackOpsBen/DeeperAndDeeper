using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    [SerializeField] float startingCapacity = 10f;
    [SerializeField] float baseBurnRate = 1f;
    [SerializeField] float burnRateIncrement = 0.1f;
    [SerializeField] float baseEfficiencyMultiplier = 1.0f;
    [SerializeField] float efficiencyIncrement = 0.5f;

    private CalculateDistance calculateDistance;

    private float currentCapacity;
    private float currentFuel;

    private UpgradeManager upgradeManager;

    //private ShipManager shipManager;

    private void Start()
    {
        calculateDistance = GetComponent<CalculateDistance>();
        currentCapacity = startingCapacity;
        currentFuel = currentCapacity;
        //shipManager = GetComponent<ShipManager>();
        upgradeManager = GetComponent<UpgradeManager>();
    }

    private void Update()
    {
        BurnFuel();
        //UpdateCapacity();
    }

    private void BurnFuel()
    {
        if (currentFuel > 0.0f)
        {
            float actualBurnRate = baseBurnRate + (burnRateIncrement * (upgradeManager.GetUpgradeMultiplier(2) - 1));
            float actualEfficiencyMultiplier = baseEfficiencyMultiplier + (efficiencyIncrement * (upgradeManager.GetUpgradeMultiplier(2) - 1));
            calculateDistance.Accelerate(Time.deltaTime * actualBurnRate * actualEfficiencyMultiplier);
            currentFuel -= Time.deltaTime * actualBurnRate;
            if (currentFuel < 0.0f)
            {
                currentFuel = 0.0f;
            }
        }
    }

    /*private void UpdateCapacity()
    {
        currentCapacity = shipManager.GetModuleOptions()[0].quantity * startingCapacity + startingCapacity; // TODO make not hardcoded
    }*/

    public void ModifyCapacity(float amount)
    {
        currentCapacity += amount;
    }

    public void Refuel()
    {
        currentFuel = currentCapacity;
    }

    public float GetCapacity()
    {
        return currentCapacity;
    }

    public float GetFuel()
    {
        return currentFuel;
    }
}
