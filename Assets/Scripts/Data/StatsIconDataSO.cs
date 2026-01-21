using UnityEngine;

[CreateAssetMenu(fileName = "StatsIconDataSO", menuName = "Scriptable Objects/StatsIconDataSO")]
public class StatsIconDataSO : ScriptableObject
{
    [field: SerializeField] public StatsIcon[] StatsIcons {get;private set;} 
}
[System.Serializable]
public struct StatsIcon
{
    public Stats stats;
    public Sprite statsIcon;
}