using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour,IGameStateListener
{
    [Header("Panel")]
    [SerializeField] private GameObject waves;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject complete;

    private List<GameObject> panels = new List<GameObject>();
    void Start()
    {
        panels.AddRange(new GameObject[]
        {
            game,
            menu,
            shop,
            waves,
            weapon,
            gameOver,
            complete
        } );
        ShowPanel(menu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStateChangeCallBack(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.MENU :
                ShowPanel(menu);
                break;
            case GameState.GAME :
                ShowPanel(game);
                break;
            case GameState.WAVETRANS :
                ShowPanel(waves);
                break;            
            case GameState.SHOP :
                ShowPanel(shop);
                break;
            case GameState.GAMEOVER:
                ShowPanel(gameOver);
                break;
            case GameState.WEAPONCHOSE:
                ShowPanel(weapon);
                break;
            case GameState.COMPLETE:
                ShowPanel(complete);
                break;
        }
        Debug.Log(gameState);
    }
    private void ShowPanel(GameObject panel)
    {
        foreach (GameObject p in panels)
        {
            p.SetActive(p==panel);
        }
    }
}
