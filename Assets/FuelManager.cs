using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    [SerializeField] float startingCapacity = 10f;
    [SerializeField] float baseBurnRate = 1f;
    [SerializeField] float burnRateIncrement = 0.1f;
    [SerializeField] float baseEfficiencyMultiplier = 1.0f;
    [SerializeField] float efficiencyIncrement = 0.5f;

    private CalculateDistance calculateDistance;

    private float currentCapacity;
    private float currentFuel;

    private UpgradeManager upgradeManager;

    [SerializeField] ParticleSystem[] thrusterPS;

    //private ShipManager shipManager;

    private void Start()
    {
        calculateDistance = GetComponent<CalculateDistance>();
        currentCapacity = startingCapacity;
        currentFuel = currentCapacity;
        //shipManager = GetComponent<ShipManager>();
        upgradeManager = GetComponent<UpgradeManager>();
    }

    private void Update()
    {
        BurnFuel();
        //UpdateCapacity();
    }

    private void BurnFuel()
    {
        if (currentFuel > 0.0f)
        {
            ToggleFX(true);
            float actualBurnRate = baseBurnRate + (burnRateIncrement * (upgradeManager.GetUpgradeMultiplier(2) - 1));
            float actualEfficiencyMultiplier = baseEfficiencyMultiplier + (efficiencyIncrement * (upgradeManager.GetUpgradeMultiplier(2) - 1));
            calculateDistance.Accelerate(Time.deltaTime * actualBurnRate * actualEfficiencyMultiplier);
            currentFuel -= Time.deltaTime * actualBurnRate;
            if (currentFuel < 0.0f)
            {
                currentFuel = 0.0f;
            }

            Camera.main.GetComponent<CameraShake>().AddShake(1f);
        }
        else
        {
            ToggleFX(false);
        }
    }

    private void ToggleFX(bool value)
    {
        if (value)
        {
            foreach (ParticleSystem ps in thrusterPS)
            {
                if (ps.isStopped)
                {
                    ps.Play();
                }
            }
            AudioManager.Instance.PlaySFXLoop("Thrust");
        }
        else
        {
            foreach (ParticleSystem ps in thrusterPS)
            {
                ps.Stop();
            }
            AudioManager.Instance.StopSFXLoop("Thrust");
        }
    }

    public void ModifyCapacity(float amount)
    {
        currentCapacity += amount;
    }

    public void Refuel()
    {
        currentFuel = currentCapacity;
    }

    public float GetCapacity()
    {
        return currentCapacity;
    }

    public float GetFuel()
    {
        return currentFuel;
    }
}
