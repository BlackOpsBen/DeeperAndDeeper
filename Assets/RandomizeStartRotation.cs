using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeStartRotation : MonoBehaviour
{
    private void Start()
    {
        float rand = UnityEngine.Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, rand, 0f);
    }
}
