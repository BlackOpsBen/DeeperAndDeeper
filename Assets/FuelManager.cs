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
            calculateDistance.Accelerate(Time.deltaTime * burnRate);
            currentFuel -= Time.deltaTime * burnRate;
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

    public float GetCapacity()
    {
        return currentCapacity;
    }

    public float GetFuel()
    {
        return currentFuel;
    }
}
