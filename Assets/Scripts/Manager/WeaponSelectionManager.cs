using System;
using System.ComponentModel;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionManager : MonoBehaviour,IGameStateListener
{
    [Header("Settings")]
    [SerializeField] private Transform containerP;
    [SerializeField] private WeaponSelectionContainer prefabs; 
    [Header("Ref")]
    [SerializeField] private WeaponDataSO[] dataSOs; 
    [SerializeField] private PlayerWeapon playerWeapon; 
    [SerializeField] private Button Next; 

    private WeaponDataSO selectedWeapon; 
    private int initialLevel;
    public void GameStateChangeCallBack(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GAME :
            case GameState.SHOP :
            case GameState.WAVETRANS :
                if(selectedWeapon == null) return;
                playerWeapon.tryAddWeapon(selectedWeapon,initialLevel);
                selectedWeapon =null;
                break;
            case GameState.WEAPONCHOSE :
                configure();
                break;
        }
    }
    [Button]
    private void configure()
    {
        foreach (Transform child in containerP) {
            Destroy(child.gameObject);
        } 
        for (int i = 0; i < 3; i++)
        {
            GenerateWeaponContainer();
        }
    }

    private void GenerateWeaponContainer()
    {
        WeaponSelectionContainer container = Instantiate(prefabs,containerP);   
        WeaponDataSO weaponDataSO = dataSOs[UnityEngine.Random.Range(0,dataSOs.Length)];

        int level = UnityEngine.Random.Range(0,4);
        int capturelv = level;
        container.Configure(weaponDataSO.Sprite,weaponDataSO.WeaponName,capturelv,weaponDataSO);
        container.button.onClick.RemoveAllListeners();
        container.button.onClick.AddListener(()=>WeaponSelectionCallback(container,weaponDataSO,capturelv));
        container.button.onClick.AddListener(()=> Next.interactable = true);
    }
    private void WeaponSelectionCallback(WeaponSelectionContainer w,WeaponDataSO d,int lv)
    {
        selectedWeapon = d;
        initialLevel = lv;
        foreach (WeaponSelectionContainer c in containerP.GetComponentsInChildren<WeaponSelectionContainer>())
        {
            if(c == w)
            {
                c.Select();
            }else c.DeSelect();
        }
    }
}
