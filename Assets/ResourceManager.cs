using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    //[SerializeField] private Resource[] resources;
    [SerializeField] private int startingData = 0;
    [SerializeField] private int startingGold = 100;

    private int data;
    private int gold;

    private void Awake()
    {
        SingletonPattern();
    }

    // Start is called before the first frame update
    void Start()
    {
        data = startingData;
        gold = startingGold;
        /*foreach (Resource resource in resources)
        {
            resource.Init();
        }*/
    }

    /*public Resource GetResource(int index)
    {
        return resources[index];
    }*/

    private void SingletonPattern()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public int GetData()
    {
        return data;
    }

    public void ModifyData(int amount)
    {
        data += amount;
    }

    public int GetGold()
    {
        return gold;
    }

    public void ModifyGold(int amount)
    {
        gold += amount;
    }
}

/*[System.Serializable]
public class Resource
{
    public string name;
    public int startingAmount;
    private int quantity;

    public int GetQuantity()
    {
        return quantity;
    }

    public void ModifyQuantity(int amount)
    {
        quantity += amount;
    }

    public void Init()
    {
        quantity = startingAmount;
    }
}*/
