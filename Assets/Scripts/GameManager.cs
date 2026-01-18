using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        SetGameState(GameState.MENU);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }
    public void SetGameState(GameState gameState)
    {
        IEnumerable<IGameStateListener> nameState =  
        FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).
        OfType<IGameStateListener>();
        foreach(IGameStateListener gameStateListener in nameState)
        {
            gameStateListener.GameStateChangeCallBack(gameState);
        }
    }
    public void WaveCompleteCallBack()
    {
        if (Player.instance.hasLevelUP())
        {
            SetGameState(GameState.WAVETRANS);
        }
        else
        {
            SetGameState(GameState.SHOP);
        }
    }
}
public interface IGameStateListener
{
    void GameStateChangeCallBack(GameState gameState);
}