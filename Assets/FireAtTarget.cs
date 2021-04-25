using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtTarget : MonoBehaviour
{
    [SerializeField] private FindTarget findTarget;

    [SerializeField] private ParticleSystem ps;

    private void Update()
    {
        if (findTarget.hasValidTarget)
        {
            if (!ps.isPlaying)
            {
                ps.Play();
            }
        }
        else
        {
            ps.Stop();
        }
    }
}
