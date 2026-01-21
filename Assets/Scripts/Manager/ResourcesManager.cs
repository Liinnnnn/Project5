using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    const string statsIconDataPath = "Data/Stats Icons";
    const string ObjectDataPath = "Data/Obj/";
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
    private static ObjectDataSO[] objectData;
    public static ObjectDataSO[] objectDataSOs
    {
        get{
            if(objectData == null)
                return objectData= Resources.LoadAll<ObjectDataSO>(ObjectDataPath);
            return objectData;
            }
        private set{}
    }
}
