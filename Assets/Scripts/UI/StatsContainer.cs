using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsContainer : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI StatsName;
    [SerializeField] private TextMeshProUGUI StatsValue;
    public void configure(Sprite i,string m , float v,bool shouldUseColor = false)
    {
        icon.sprite = i;
        StatsName.text = m;
        StatsValue.text = v.ToString("F2");

        if (shouldUseColor)
        {
            ColorizeText(v);
        }else
        {
            StatsValue.color = Color.white;
            StatsValue.text = v.ToString("F2");

        }
    }
    private void ColorizeText(float statsValue)
    {
        float sign = MathF.Sign(statsValue);
        if(statsValue == 0) sign = 0;

        float absVal = MathF.Abs(statsValue);

        Color StatsColor = Color.white;
        if (sign > 0)
            StatsColor = Color.green;
        else if (sign < 0)     
            StatsColor = Color.red;
        StatsValue.color = StatsColor;
        StatsValue.text = absVal.ToString("F2");
    }
}
