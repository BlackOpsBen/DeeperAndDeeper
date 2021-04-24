using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewShip : MonoBehaviour
{
    [SerializeField] GameObject baseThrusters;
    [SerializeField] GameObject[] moduleOptions;
    [SerializeField] GameObject endCap;

    private GameObject bottomPiece;
    private List<GameObject> modules = new List<GameObject>();
    private GameObject topPiece;

    public float moduleSize = 2f;

    // Start is called before the first frame update
    void Start()
    {
        bottomPiece = Instantiate(baseThrusters);
        topPiece = Instantiate(endCap);
    }

    // Update is called once per frame
    void Update()
    {
        float verticalOffset = moduleSize * (modules.Count + 1);
        topPiece.transform.position = new Vector3(0f, verticalOffset, 0f);
    }
}
