using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayShip : MonoBehaviour
{
    [SerializeField] GameObject baseThrusters;
    [SerializeField] GameObject endCap;

    private List<GameObject> modules = new List<GameObject>();

    private float moduleSize = 2f;

    // Update is called once per frame
    void Update()
    {
        UpdateEndCapPosition();
    }

    private void UpdateEndCapPosition()
    {
        float verticalOffset = moduleSize * (modules.Count + 1);
        endCap.transform.position = new Vector3(0f, verticalOffset, 0f);
    }

    public void AddModule(GameObject moduleObject)
    {
        float verticalOffset = moduleSize * (modules.Count + 1);
        GameObject addedModule = Instantiate(moduleObject);
        modules.Add(addedModule);
        addedModule.transform.position = new Vector3(0f, verticalOffset, 0f);
    }
}
