using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class ChestContainerUI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Image icon ;
    [SerializeField] private TextMeshProUGUI ObjectName ;
    [field : SerializeField] public Button TakeButton{get;private set;}
    [field : SerializeField] public Button RecycleButton{get;private set;}
    [field : SerializeField] public TextMeshProUGUI RecycleTextMeshProUGUI{get;private set;}
    [Header("Stats")]
    [SerializeField] private Transform statsContainerP;
    [Header("Color")]
    [SerializeField] private Image rarityImage;
    void Awake()
    {
        
    }
    public void Configure(ObjectDataSO w)
    {
        icon.sprite = w.icon;
        ObjectName.text = w.Name;
        Color imgColor = ColorHolder.getColor(w.rarity);
        ObjectName.color = imgColor;
        rarityImage.color = imgColor;
        RecycleTextMeshProUGUI.text = w.sellPrice.ToString();
        configureStatsContainer(w.BaseStat);
    }

    private void configureStatsContainer(Dictionary<Stats,float> stat)
    {
        StatsContainerManager.GenerateStatsContainer(stat,statsContainerP);
    }
}
