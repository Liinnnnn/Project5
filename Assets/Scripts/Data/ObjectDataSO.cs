using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectDataSO", menuName = "Scriptable Objects/ObjectDataSO")]
public class ObjectDataSO : ScriptableObject
{
    [field : SerializeField] public string Name {get;private set;}
    [field : SerializeField] public Sprite icon {get;private set;}
    [field : SerializeField] public int sellPrice {get;private set;}
    [field : Range(0,3)]
    [field : SerializeField] public int rarity {get;private set;}
    [SerializeField] private StatData[] statDatas;  
    public Dictionary<Stats,float> BaseStat
    {
        get
        {
                Dictionary<Stats,float> stats = new Dictionary<Stats, float>();
                foreach (StatData i in statDatas)
                {
                    stats.Add(i.stats,i.value);
                }
                return stats;

        }
    
    }
    
}
[System.Serializable]
public struct StatData
{
    public Stats stats;
    public float value;
}
