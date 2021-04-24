using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitShipInView : MonoBehaviour
{
    [SerializeField] private Transform targetBottom;
    [SerializeField] private Transform targetTop;
    [SerializeField] private float lerpSpeed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        float shipHeight = Vector3.Distance(targetBottom.position, targetTop.position);
        Vector3 targetPosition = new Vector3(0f, targetTop.position.y - shipHeight / 2, -shipHeight);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed);
    }
}
