using System.Collections.Generic;
using UnityEngine;

public class StatsContainerManager : MonoBehaviour
{
    public static StatsContainerManager instance;
    [SerializeField] private StatsContainer statsContainer;
    void Awake()
    {
        instance = this;
    }
    private void Generate(Dictionary<Stats,float> statsDict , Transform parent)
    {
        foreach (KeyValuePair<Stats,float> k in statsDict)
        {
            StatsContainer container = Instantiate(statsContainer,parent);
            Sprite icon = ResourcesManager.GetStatsIcon(k.Key);
            string name = Enums.FormatStatName(k.Key);
            float val = k.Value;
            container.configure(icon,name , val);
        }
    }
    public static void GenerateStatsContainer(Dictionary<Stats,float> statsDict , Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
        instance.Generate(statsDict,parent);
    }
}
