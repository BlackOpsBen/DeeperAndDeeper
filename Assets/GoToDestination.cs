using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDestination : MonoBehaviour
{
    private Vector3 destination;
    [SerializeField] float moveSpeed = 1f;

    private void Awake()
    {
        destination = new Vector3(0f, 0f, transform.position.z);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * moveSpeed);
    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = new Vector3(newDestination.x, newDestination.y, transform.position.z);
    }
}
