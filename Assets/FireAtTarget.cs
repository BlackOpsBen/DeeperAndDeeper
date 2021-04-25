using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtTarget : MonoBehaviour
{
    [SerializeField] private FindTarget findTarget;

    [SerializeField] private ParticleSystem ps;

    private float interval = 1f;

    private float timer = 0f;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (findTarget.hasValidTarget)
        {
            if (timer < 0.0f)
            {
                ps.Play();
                AudioManager.Instance.PlaySFX("Laser");
                timer = interval;
            }
        }
        else
        {
            ps.Stop();
        }
    }
}
