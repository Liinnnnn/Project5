using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Scriptable Objects/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    [field: SerializeField] private string PName{get;set;}
    [field: SerializeField] private Sprite Sprite{get;set;}
    [field: SerializeField] private float price{get;set;}
    [HorizontalLine]
    [SerializeField] private float Attack;
    [SerializeField] private float AttackSpeed;
    [SerializeField] private float CritChance;
    [SerializeField] private float CritDamage;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float MaxHp;
    [SerializeField] private float Range;
    [SerializeField] private float HpRecoveryRate;
    [SerializeField] private float Armor;
    [SerializeField] private float Luck;
    [SerializeField] private float Dodge;
    [SerializeField] private float LifeSteal;
    
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
                {Stats.MoveSpeed, MoveSpeed},
                {Stats.MaxHp, MaxHp},
                {Stats.Range, Range},
                {Stats.HpRecoveryRate, HpRecoveryRate},
                {Stats.Armor, Armor},
                {Stats.Luck, Luck},
                {Stats.Dodge, Dodge},
                {Stats.LifeSteal, LifeSteal}
            };
        }
    }
}
