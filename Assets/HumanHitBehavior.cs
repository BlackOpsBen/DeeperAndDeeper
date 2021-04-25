using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHitBehavior : MonoBehaviour, IHit
{

    [SerializeField] private ParticleSystem hitPFX;

    public void TriggerHitBehavior()
    {
        hitPFX.Play();
        AudioManager.Instance.PlayExplosion();
    }
}
