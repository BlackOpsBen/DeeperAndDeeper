using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitShipInView : MonoBehaviour
{
    [SerializeField] private Transform targetBottom;
    [SerializeField] private Transform targetTop;

    void Start()
    {
        
    }

    void Update()
    {
        float shipHeight = Vector3.Distance(targetBottom.position, targetTop.position);
        transform.position = new Vector3(0f, targetTop.position.y - shipHeight / 2, -shipHeight);
    }
}
