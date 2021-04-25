using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseStreaksWithSpeed : MonoBehaviour
{
    private CalculateDistance calculateDistance;
    private ParticleSystem ps;

    [SerializeField] private int minRate = 0;
    [SerializeField] private int maxRate = 2000;

    [SerializeField] private float minSpeed = 50f;
    [SerializeField] private float maxSpeed = 5000f;

    ParticleSystem.EmissionModule em;

    private void Start()
    {
        calculateDistance = FindObjectOfType<CalculateDistance>();
        ps = GetComponent<ParticleSystem>();
        em = ps.emission;
    }

    private void Update()
    {
        float lerpSpeed = (calculateDistance.GetSpeed() - minSpeed) / (maxSpeed - minSpeed);
        em.rateOverTime = Mathf.Lerp(minRate, maxRate, lerpSpeed);
    }
}
