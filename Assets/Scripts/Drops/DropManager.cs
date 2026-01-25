using UnityEngine;
using UnityEngine.Pool;

public class DropManager : MonoBehaviour,IPlayerStats
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private XP XP;
    [SerializeField] private Coins coin;
    [SerializeField] private Chest chest;
    // [SerializeField] private Diamond diamond;
    [Header("Setting")]
    [SerializeField][Range(0,50)] private float coinDropChance;
    [SerializeField][Range(0,100)] private float chestDropChance;

    private ObjectPool<XP> XPPool; 
    private ObjectPool<Coins> coinPool; 
    // private ObjectPool<Diamond> diaPool; 
    void Awake()
    {
        Enemy.onDying += Drop;
        XPPool = new ObjectPool<XP>(XPCreateFunc,XPActionOnGet,XPActionOnRelease,XPActionOnDestroy);
        coinPool = new ObjectPool<Coins>(coinCreateFunc,coinActionOnGet,coinActionOnRelease,coinActionOnDestroy);
        // diaPool = new ObjectPool<Diamond>(diamondCreateFunc,diamondActionOnGet,diamondActionOnRelease,diamondActionOnDestroy);
        XP.onCollected += ReleaseXP;
        Coins.onCollected += ReleaseCoins;
        // Diamond.onCollected += ReleaseDiamond;
    }


    private XP XPCreateFunc() =>Instantiate(XP, transform);
    private void XPActionOnGet(XP XP) => XP.gameObject.SetActive(true);
    private void XPActionOnRelease(XP XP) => XP.gameObject.SetActive(false);
    private void XPActionOnDestroy(XP XP) => Destroy(XP.gameObject);
    private Coins coinCreateFunc() =>Instantiate(coin, transform);
    private void coinActionOnGet(Coins Coin) => Coin.gameObject.SetActive(true);
    private void coinActionOnRelease(Coins Coin) => Coin.gameObject.SetActive(false);
    private void coinActionOnDestroy(Coins Coin) => Destroy(Coin.gameObject);
    // private Diamond diamondCreateFunc() =>Instantiate(diamond, transform);
    // private void diamondActionOnGet(Diamond Dia) => Dia.gameObject.SetActive(true);
    // private void diamondActionOnRelease(Diamond Dia) => Dia.gameObject.SetActive(false);
    // private void diamondActionOnDestroy(Diamond Dia) => Destroy(Dia.gameObject);
    void OnDestroy()
    {
        Enemy.onDying -=Drop;
        XP.onCollected -= ReleaseXP;
        Coins.onCollected -= ReleaseCoins;
        // Diamond.onCollected -=ReleaseDiamond;
    }
    private void Drop(Vector2 enemyPos)
    {
        Dropables gojb = XPPool.Get();
        gojb.transform.position = enemyPos;
        tryDropCoin(enemyPos);
        TryDropChest(enemyPos);
    }

    private void TryDropChest(Vector2 enemyPos)
    {
        bool shouldSpawnChest = Random.Range(0f,101f) <= chestDropChance;
        if(!shouldSpawnChest) return;

        Instantiate(chest,enemyPos,Quaternion.identity,transform);
    }
    private void tryDropCoin(Vector2 vector2)
    {
        bool shouldDropDia = Random.Range(0f,101f) <= coinDropChance;
        if(!shouldDropDia) return;

        Instantiate(coin,vector2 + new Vector2(.3f,.3f),Quaternion.identity,transform);
    }
    private void ReleaseXP(XP XP) => XPPool.Release(XP);
    private void ReleaseCoins(Coins Coins) => coinPool.Release(Coins);

    // private void ReleaseDiamond(Diamond diamond)=> diaPool.Release(diamond);
    public void updateStat(PlayerStatsManager playerStatsManager)
    {
        float Luck = playerStatsManager.GetStatsValue(Stats.Luck)/100;
        // diaDropChance = diaDropChance * (1 + Luck);
        chestDropChance = chestDropChance * (1 + Luck/3);
    }
}
