using System.Collections.Generic;
using UnityEngine;

public static class WeaponStatsCalculated 
{
    public static Dictionary<Stats,float> GetStats(WeaponDataSO sp,float level)
    {
        float multiplier = 1 + (float)level/5;
        Dictionary<Stats,float> calculatedStats = new Dictionary<Stats, float>();
        foreach (KeyValuePair<Stats,float> kvp in sp.BaseStat)
        {
            if(sp.weapon.GetType() != typeof(RangedWeapon) && kvp.Key == Stats.Range)
            {
                calculatedStats.Add(kvp.Key,kvp.Value);
            }else
            {
                calculatedStats.Add(kvp.Key,kvp.Value * multiplier);
            }
            
        }
        return calculatedStats;
    }
    public static int GetPrice(WeaponDataSO a,float level)
    {
        return Mathf.RoundToInt(a.price * ((int )level + 1));
    }
    public static int GetSellPrice(WeaponDataSO a,float level)
    {
        return Mathf.RoundToInt(a.price * ((int )level + 1) / 2);
    }
}
