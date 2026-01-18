using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WavesTransManager : MonoBehaviour,IGameStateListener
{
    [Header("Refs")]
    [SerializeField] private Button[] upgrades;
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

    private void Configure()
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            upgrades[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Upgrade " + i;
        }
    }
}
