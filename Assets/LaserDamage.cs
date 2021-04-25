using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    [SerializeField] int damage = 1;

    private void OnParticleCollision(GameObject other)
    {
        Debug.LogWarning("Particle hit " + other.name);
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            Debug.Log("Health found");
            health.ModifyHealth(-damage);
        }
    }
}
