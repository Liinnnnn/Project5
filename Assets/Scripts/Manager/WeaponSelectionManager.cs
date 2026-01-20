using System;
using System.ComponentModel;
using NaughtyAttributes;
using UnityEngine;

public class WeaponSelectionManager : MonoBehaviour,IGameStateListener
{
    [Header("Settings")]
    [SerializeField] private Transform containerP;
    [SerializeField] private WeaponSelectionContainer prefabs; 
    [Header("Settings")]
    [SerializeField] private WeaponDataSO[] dataSOs; 
    [SerializeField] private PlayerWeapon playerWeapon; 
    private WeaponDataSO selectedWeapon; 
    private int initialLevel;
    public void GameStateChangeCallBack(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GAME :
                if(selectedWeapon == null) return;
                playerWeapon.AddWeapon(selectedWeapon,initialLevel);
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
        initialLevel = level;
        container.Configure(weaponDataSO.Sprite,weaponDataSO.WeaponName,level);
        container.button.onClick.RemoveAllListeners();
        container.button.onClick.AddListener(()=>WeaponSelectionCallback(container,weaponDataSO));
    }
    private void WeaponSelectionCallback(WeaponSelectionContainer w,WeaponDataSO d)
    {
        selectedWeapon = d;
        foreach (WeaponSelectionContainer c in containerP.GetComponentsInChildren<WeaponSelectionContainer>())
        {
            if(c == w)
            {
                c.Select();
            }else c.DeSelect();
        }
    }
}
