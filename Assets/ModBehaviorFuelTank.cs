using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBehaviorFuelTank : MonoBehaviour
{
    private FuelManager fuelManager;

    private float capacity = 10f;

    private void Start()
    {
        fuelManager = FindObjectOfType<FuelManager>();
        fuelManager.ModifyCapacity(capacity);
    }
}
