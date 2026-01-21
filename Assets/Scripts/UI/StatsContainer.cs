using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsContainer : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI StatsName;
    [SerializeField] private TextMeshProUGUI StatsValue;
    public void configure(Sprite i,string m , string v)
    {
        icon.sprite = i;
        StatsName.text = m;
        StatsValue.text = v;
    }
}
