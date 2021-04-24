using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBehaviorProbe : MonoBehaviour
{
    private float interval = .5f;

    private float timer = 0f;

    private int amountCollected = 6;

    private ResourceManager resourceManager;

    private UpgradeManager upgradeManager;

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        upgradeManager = FindObjectOfType<UpgradeManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            resourceManager.ModifyData(Mathf.RoundToInt(amountCollected * upgradeManager.GetUpgradeMultiplier(0)));
            timer = 0f;
        }
    }
}
