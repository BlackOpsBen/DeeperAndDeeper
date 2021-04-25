using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDieBehavior : MonoBehaviour, IDie
{
    public void Die()
    {
        Debug.LogWarning("Enemy Destroyed!");
    }
}
