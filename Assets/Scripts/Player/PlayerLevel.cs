using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Settings")]
    private float level;
    private float currentXp;
    private float requiredXp;
    private int levelThisWave;
    [Header("Ref")]
    [SerializeField] private Slider xpBar;
    [SerializeField] private TextMeshProUGUI lv;
    void Start()
    {
        xpBar.value = 0;
        UpdateXP();
        UpdateSlider();
        XP.onCollected +=getXP;
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateXP()
    {
        requiredXp = (level + 1) * 5;
    }
    private void UpdateSlider()
    {
        xpBar.value = currentXp / requiredXp;
        lv.text = "lvl. " + (level + 1);
    }
    private void getXP(XP xp)
    {   
        currentXp+= 1;
        if(currentXp >= requiredXp)
        {
            levelUP();
        }
        UpdateSlider();
    }

    private void levelUP()
    {
        currentXp = 0;
        levelThisWave++;
        level+=1;
        UpdateXP();
    }
    public bool hasLevelUP()
    {
        if(levelThisWave > 0)
        {
            levelThisWave--;
            return true;
        }
        return false;
    }
}
