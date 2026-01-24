using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    [field :SerializeField] public List<ObjectDataSO> objects {get; private set;}
    private PlayerStatsManager playerStatsManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (ObjectDataSO data in objects)
        {
            playerStatsManager.AddObject(data.BaseStat);
        }
    }
    void Awake()
    {
        playerStatsManager = GetComponent<PlayerStatsManager>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObject(ObjectDataSO randomObj)
    {
        objects.Add(randomObj);
        playerStatsManager.AddObject(randomObj.BaseStat);
    }
    public void recyle(ObjectDataSO objectDataSO)
    {
        objects.Remove(objectDataSO);

        CurrencyManager.instance.AddCurrency(objectDataSO.sellPrice);

        playerStatsManager.RemoveObjecStats(objectDataSO.BaseStat);
    }
}
