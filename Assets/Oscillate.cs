using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
    [SerializeField] private bool enableXRotation;
    [SerializeField] private float xAmplitude = 45f;
    [SerializeField] private float xPeriod = 0f;
    [SerializeField] private float xSpeed = 1f;
    private float startXRotation;
    
    [SerializeField] private bool enableZRotation;
    [SerializeField] private float zAmplitude = 45f;
    [SerializeField] private float zPeriod = 0f;
    [SerializeField] private float zSpeed = 1f;
    private float startZRotation;

    private void Start()
    {
        xSpeed = UnityEngine.Random.Range(0f, xSpeed);
        zSpeed = UnityEngine.Random.Range(0f, zSpeed);
        startXRotation = transform.localRotation.x;
        startZRotation = transform.localRotation.z;
    }

    private void Update()
    {
        if (enableXRotation)
        {
            xPeriod += Time.deltaTime * xSpeed;
            float xRotation = xAmplitude * Mathf.Sin(xPeriod);
            transform.localRotation = Quaternion.Euler(startXRotation + xRotation, transform.localRotation.y, transform.localRotation.z);
        }

        if (enableZRotation)
        {
            zPeriod += Time.deltaTime * zSpeed;
            float zRotation = zAmplitude * Mathf.Sin(zPeriod);
            transform.localRotation = Quaternion.Euler(startXRotation, transform.localRotation.y, startZRotation + zRotation);
        }
    }
}
