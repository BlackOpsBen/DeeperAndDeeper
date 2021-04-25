using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToTarget : MonoBehaviour
{
    private FindTarget findTarget;
    [SerializeField] private float lerpSpeed = 3f;

    private void Start()
    {
        findTarget = GetComponent<FindTarget>();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, findTarget.GetTarget().position, Time.deltaTime * lerpSpeed);
    }
}
