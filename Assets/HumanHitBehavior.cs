using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHitBehavior : MonoBehaviour, IHit
{
    public void TriggerHitBehavior()
    {
        Debug.LogWarning("Enemy hit!");
    }
}
