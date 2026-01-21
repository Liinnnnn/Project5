using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetGameState(GameState.MENU);
        Application.targetFrameRate = 60;
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
    public void startGame()
    {
        SetGameState(GameState.GAME);
    }
    public void openShop()
    {
        SetGameState(GameState.SHOP);
    }
    public void openWeapon()
    {
        SetGameState(GameState.WEAPONCHOSE);
    }
    public void openUpgrade()
    {
        SetGameState(GameState.WAVETRANS);
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

    public void ManagerGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WaveCompleteCallBack()
    {
        if (Player.instance.hasLevelUP() || WavesTransManager.instance.HasCollectedChest())
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