using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Scriptable Objects/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public string WeaponName{get;set;}
    [field: SerializeField] public Sprite Sprite{get;set;}
    [field: SerializeField] public float price{get;set;}
    [field: SerializeField] public Weapon weapon{get;set;}
    [HorizontalLine]
    [SerializeField] private float Attack;
    [SerializeField] private float AttackSpeed;
    [SerializeField] private float CritChance;
    [SerializeField] private float Range;
    [SerializeField] private float CritDamage;
    public Dictionary<Stats,float> BaseStat
    {
        get
        {
            return new Dictionary<Stats, float>
            {
                {Stats.Attack, Attack},
                {Stats.AttackSpeed, AttackSpeed},
                {Stats.CritChance, CritChance},
                {Stats.CritDamage, CritDamage},
                {Stats.Range, Range},
            };
        }
        private set{}
    }
    public float getStats(Stats stats)
    {
        foreach (KeyValuePair<Stats,float> p in BaseStat)
        {
            if(p.Key == stats)
                return p.Value;
        }
        Debug.Log("Loi o" + stats);
        return 0;
    }
}
