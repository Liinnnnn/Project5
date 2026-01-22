using System;
using UnityEngine;

public class PlayerStatsDisplay : MonoBehaviour,IPlayerStats
{
    [SerializeField] private Transform playerStatsContainer;
    public void updateStat(PlayerStatsManager playerStatsManager)
    {
        int index = 0;
        foreach (Stats stats in Enum.GetValues(typeof(Stats)))
        {
            StatsContainer statsContainer = playerStatsContainer.GetChild(index).GetComponent<StatsContainer>();
            statsContainer.gameObject.SetActive(true);

            Sprite statsIcon = ResourcesManager.GetStatsIcon(stats);
            float v = playerStatsManager.GetStatsValue(stats);
            statsContainer.configure(statsIcon,Enums.FormatStatName(stats),v,true);
            index++;
        }
        for (int i = index; i < playerStatsContainer.childCount; i++)
        {
            playerStatsContainer.GetChild(i).gameObject.SetActive(false);
        }
    }

}
