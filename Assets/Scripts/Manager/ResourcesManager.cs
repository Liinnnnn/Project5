using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    const string statsIconDataPath = "Data/Stats Icons";
    private static StatsIcon[] icon ;
    public static Sprite GetStatsIcon(Stats stats)
    {
        if (icon == null)
        {
            StatsIconDataSO dataSO = Resources.Load<StatsIconDataSO>(statsIconDataPath);
            icon = dataSO.StatsIcons;
        }
        foreach (StatsIcon i in icon)
        {
            if(stats == i.stats)
            {
                return i.statsIcon;
            }
        }
        return null;
    } 
}
