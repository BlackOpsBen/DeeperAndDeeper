using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    [SerializeField] float startingCapacity = 10f;
    [SerializeField] float burnRate = 1f;

    private CalculateDistance calculateDistance;

    private float currentCapacity;
    private float currentFuel;

    private ShipManager shipManager;

    private void Start()
    {
        calculateDistance = GetComponent<CalculateDistance>();
        currentCapacity = startingCapacity;
        currentFuel = currentCapacity;
        shipManager = GetComponent<ShipManager>();
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
            calculateDistance.Accelerate(Time.deltaTime * burnRate);
            currentFuel -= Time.deltaTime * burnRate;
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
