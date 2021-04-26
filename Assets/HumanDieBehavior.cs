using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDieBehavior : MonoBehaviour, IDie
{
    [SerializeField] GameObject diePFXPrefab;

    [SerializeField] int goldValue;

    public void Die()
    {
        Debug.Log("Enemy killed");
        Instantiate(diePFXPrefab, transform.position, Quaternion.identity);
        AudioManager.Instance.PlayExplosion();
        ResourceManager.Instance.ModifyGold(goldValue);
        Destroy(gameObject);
    }
}
