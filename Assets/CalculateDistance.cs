using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    private float distance = 0f;

    private float speed = 0f;

    private void Update()
    {
        distance += speed * Time.deltaTime;
    }

    public void Accelerate(float amount)
    {
        speed += amount;
    }

    public float GetDistance()
    {
        return distance;
    }

    public string GetDistanceString()
    {
        string formattedDistance = $"{distance:0.0}";
        return formattedDistance + " km";
    }

    public string GetSpeedString()
    {
        float kmps = speed;
        string formattedKmps = $"{kmps:0.0}";
        return formattedKmps + " km/s";
    }
}
