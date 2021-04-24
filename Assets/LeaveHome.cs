using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveHome : MonoBehaviour
{
    private CalculateDistance calculateDistance;

    private float startingYPos;

    private void Start()
    {
        calculateDistance = FindObjectOfType<CalculateDistance>();

        startingYPos = transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, startingYPos - calculateDistance.GetDistance(), transform.position.z);
    }
}
