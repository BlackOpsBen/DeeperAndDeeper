using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBehaviorLifeSupport : MonoBehaviour
{
    private float interval = 1f;

    private float timer = 0f;

    private int amountCollected = 1;

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
            resourceManager.ModifyGold(amountCollected);
            timer = 0f;
        }
    }
}
