using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDieBehavior : MonoBehaviour, IDie
{
    [SerializeField] GameObject diePFXPrefab;

    public void Die()
    {
        Instantiate(diePFXPrefab, transform.position, Quaternion.identity);
        AudioManager.Instance.PlayExplosion();
        Destroy(gameObject);
    }
}
