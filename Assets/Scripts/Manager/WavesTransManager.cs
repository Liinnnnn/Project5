using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WavesTransManager : MonoBehaviour,IGameStateListener
{
    [Header("Refs")]
    [SerializeField] private Upgrades[] upgrades;
    [SerializeField] private PlayerStatsManager statsManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStateChangeCallBack(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.WAVETRANS :
                Configure();
                break;
        }    
    }
    [Button]
    private void Configure()
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0,Enum.GetValues(typeof(Stats)).Length);
            Stats stats = (Stats) Enum.GetValues(typeof(Stats)).GetValue(randomIndex);
            string randomUpg = Enums.FormatStatName(stats);

            string buttonString;
            Action action = GetPerformedAction(stats,out buttonString);

            upgrades[i].configure(null,randomUpg,buttonString);
            upgrades[i].button.onClick.RemoveAllListeners();
            upgrades[i].button.onClick.AddListener(() => action?.Invoke());
            upgrades[i].button.onClick.AddListener(() => BonusSelectedCallback());

        }
    }
    private void BonusSelectedCallback()
    {
        GameManager.instance.WaveCompleteCallBack();
    }
    private Action GetPerformedAction(Stats stats,out string buttonString)
    {
        buttonString = "";
        float value;
        value = UnityEngine.Random.Range(1,10);


        switch (stats)
        {
            case Stats.Attack:
                value = UnityEngine.Random.Range(1,10);
                buttonString = "+ " + value.ToString() +"%"; 
                break;
            case Stats.AttackSpeed :
                value = UnityEngine.Random.Range(1,10);
                buttonString = "+ " + value.ToString() +"%";
                break;
            case Stats.CritChance :
                value = UnityEngine.Random.Range(1f,2f);
                buttonString = "+ " + value.ToString("F2") + "x";
                break;
            case Stats.CritDamage :
                value = UnityEngine.Random.Range(1,10);
                buttonString = "+ " + value.ToString() +"%";
                break;
            case Stats.MoveSpeed :
                value = UnityEngine.Random.Range(1,10);
                buttonString = "+ " + value.ToString() +"%";
                break;
            case Stats.MaxHp :
                value = UnityEngine.Random.Range(1,5);
                buttonString = "+ " + value;
                break;
            case Stats.Range :
                value = UnityEngine.Random.Range(0f,1f);
                buttonString = "+ " + value.ToString("F2");
                break;
            case Stats.HpRecoveryRate :
                value = UnityEngine.Random.Range(1,10);
                buttonString = "+ " + value.ToString() +"%";
                break;
            case Stats.Armor :
                value = UnityEngine.Random.Range(1,10);
                buttonString = "+ " + value.ToString() +"%";
                break;
            case Stats.Luck :
                value = UnityEngine.Random.Range(1,10);
                buttonString = "+ " + value.ToString() +"%";
                break;
            case Stats.Dodge :
                value = UnityEngine.Random.Range(1,10);
                buttonString = "+ " + value.ToString() +"%";
                break;
            case Stats.LifeSteal :
                value = UnityEngine.Random.Range(1,10);
                buttonString = "+ " + value.ToString() +"%";
                break;
        }
        return ()=> statsManager.AddStats(stats,value) ;
    }
}
