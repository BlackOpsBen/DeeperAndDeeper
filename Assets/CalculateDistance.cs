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

    public int GetDistance()
    {
        return Mathf.RoundToInt(distance);
    }
}
