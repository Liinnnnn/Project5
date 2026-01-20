using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Burst.Intrinsics;
public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerDataSO;
    private Dictionary<Stats,float> statsData = new Dictionary<Stats, float>();
    private Dictionary<Stats,float> playerStats = new Dictionary<Stats, float>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updatePlayerStat();
    }
    void Awake()
    {
        playerStats = playerDataSO.BaseStat; 
        foreach(KeyValuePair<Stats,float> k in playerStats)
        {
            statsData.Add(k.Key,k.Value);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddStats(Stats stats,float v)
    {
        if (statsData.ContainsKey(stats))
        {
            statsData[stats] += v;
            Debug.Log("Add " + stats + " " + v);
        }else
        {
            Debug.Log("NOTHING");
        }
        updatePlayerStat();
    }

    private void updatePlayerStat()
    {
        IEnumerable<IPlayerStats> playerStats =  
        FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).
        OfType<IPlayerStats>();
        foreach(IPlayerStats s in playerStats)
        {
            s.updateStat(this);
        }
    }

    public float GetStatsValue(Stats stats)
    {
        return statsData[stats];
    }
}
