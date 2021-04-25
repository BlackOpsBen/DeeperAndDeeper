using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtNearestModule : MonoBehaviour
{
    private Vector3 target;

    private void Update()
    {
        transform.LookAt(target);
    }
}
