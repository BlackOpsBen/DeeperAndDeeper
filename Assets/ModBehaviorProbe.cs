using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBehaviorProbe : MonoBehaviour
{
    private float interval = .5f;

    private float timer = 0f;

    private int amountCollected = 6;

    private ResourceManager resourceManager;

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            resourceManager.ModifyData(amountCollected);
            timer = 0f;
        }
    }
}
