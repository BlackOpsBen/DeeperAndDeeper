using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    [SerializeField] Transform defaultTarget;

    private GameObject[] targets;
    private Transform nearestTarget;

    public bool hasValidTarget = false;

    private void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");

        nearestTarget = FindNearestTarget();
    }

    private Transform FindNearestTarget()
    {
        if (targets.Length == 0)
        {
            hasValidTarget = false;
            return defaultTarget;
        }
        else
        {
            Transform closestTarget = targets[0].transform;
            float closestTargetDist = Vector3.Distance(transform.position, closestTarget.position);

            for (int i = 0; i < targets.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, targets[i].transform.position);
                if (distance < closestTargetDist)
                {
                    closestTarget = targets[i].transform;
                    closestTargetDist = distance;
                }
            }

            hasValidTarget = true;
            return closestTarget;
        }
    }

    public Transform GetTarget()
    {
        return nearestTarget;
    }
}
