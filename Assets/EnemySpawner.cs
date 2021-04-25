using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform topOfShip;
    [SerializeField] Transform bottomOfShip;

    [SerializeField] SpawnableEnemy[] spawnableEnemies;

    [SerializeField] float spawnPlaneZOffset = 5f;

    private CalculateDistance calculateDistance;

    private float[] timers;

    private void Start()
    {
        calculateDistance = FindObjectOfType<CalculateDistance>();

        timers = new float[spawnableEnemies.Length];
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] = 0.0f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] -= Time.deltaTime;

            if (timers[i] < 0.0f)
            {
                if (calculateDistance.GetDistance() > spawnableEnemies[i].minDistance)
                {
                    Spawn(i);
                    timers[i] = spawnableEnemies[i].GetCurrentInterval(calculateDistance.GetDistance());
                }
            }
        }
    }

    private void Spawn(int enemyIndex)
    {
        GameObject newEnemy = Instantiate(spawnableEnemies[enemyIndex].enemyPrefab, GetSpawnPosition(), Quaternion.identity, transform);
        GoToDestination goToDestination = newEnemy.GetComponent<GoToDestination>();
        goToDestination.SetDestination(GetDestination());
    }

    private Vector3 GetDestination()
    {
        float shipHeight = Vector3.Distance(topOfShip.position, bottomOfShip.position);
        float destX = UnityEngine.Random.Range(-shipHeight / 2f, shipHeight / 2f);
        float destY = UnityEngine.Random.Range(-shipHeight / 2f, shipHeight / 2f) + shipHeight / 2f;
        float destZ = 0f;
        Vector3 value = new Vector3(destX, destY, destZ);
        return value;
    }

    private Vector3 GetSpawnPosition()
    {
        float shipHeight = Vector3.Distance(topOfShip.position, bottomOfShip.position);
        float startX = shipHeight * Mathf.Sign(UnityEngine.Random.Range(-1f, 1f));
        float startY = shipHeight * Mathf.Sign(UnityEngine.Random.Range(-1f, 1f));
        float startZ = spawnPlaneZOffset * Mathf.Sign(UnityEngine.Random.Range(-1f, 1f));
        return new Vector3(startX, startY, startZ);
    }
}

[System.Serializable]
public class SpawnableEnemy
{
    public GameObject enemyPrefab;

    public float slowestInterval = 20f;
    public float minDistance = 5000f;

    public float fastestInterval = 1f;
    public float fastestDistance = 1000000f;

    public float GetCurrentInterval(float currentDistance)
    {
        float lerpT = (currentDistance - minDistance) / (fastestDistance - minDistance);

        return Mathf.Lerp(slowestInterval, fastestInterval, lerpT);
    }
}
