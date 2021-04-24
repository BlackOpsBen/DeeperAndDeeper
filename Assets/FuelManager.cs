using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    [SerializeField] float startingCapacity = 100f;

    private CalculateDistance calculateDistance;

    private float currentCapacity;
    private float currentFuel;

    private void Start()
    {
        calculateDistance = GetComponent<CalculateDistance>();
        currentCapacity = startingCapacity;
        currentFuel = currentCapacity;
    }

    private void Update()
    {
        if (currentFuel > 0.0f)
        {
            calculateDistance.Accelerate(Time.deltaTime);
            currentFuel -= Time.deltaTime;
            if (currentFuel < 0.0f)
            {
                currentFuel = 0.0f;
            }
        }
    }

    public void Refuel()
    {
        currentFuel = currentCapacity;
    }
}
