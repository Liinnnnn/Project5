using UnityEngine;
using UnityEngine.Pool;

public class DropManager : MonoBehaviour,IPlayerStats
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private XP XP;
    [SerializeField] private Coins coin;
    [SerializeField] private Chest chest;
    [Header("Setting")]
    [SerializeField][Range(0,100)] private float coinDropChance;
    [SerializeField][Range(0,100)] private float chestDropChance;

    private ObjectPool<XP> XPPool; 
    private ObjectPool<Coins> coinPool; 
    void Start()
    {
        Enemy.onDying += Drop;
        XPPool = new ObjectPool<XP>(XPCreateFunc,XPActionOnGet,XPActionOnRelease,XPActionOnDestroy);
        coinPool = new ObjectPool<Coins>(coinCreateFunc,coinActionOnGet,coinActionOnRelease,coinActionOnDestroy);
        XP.onCollected += ReleaseXP;
        Coins.onCollected += ReleaseCoins;
    }
    private XP XPCreateFunc() =>Instantiate(XP, transform);
    private void XPActionOnGet(XP XP) => XP.gameObject.SetActive(true);
    private void XPActionOnRelease(XP XP) => XP.gameObject.SetActive(false);
    private void XPActionOnDestroy(XP XP) => Destroy(XP.gameObject);
    private Coins coinCreateFunc() =>Instantiate(coin, transform);
    private void coinActionOnGet(Coins Coin) => Coin.gameObject.SetActive(true);
    private void coinActionOnRelease(Coins Coin) => Coin.gameObject.SetActive(false);
    private void coinActionOnDestroy(Coins Coin) => Destroy(Coin.gameObject);
    void OnDestroy()
    {
        Enemy.onDying -=Drop;
        XP.onCollected -= ReleaseXP;
        Coins.onCollected -= ReleaseCoins;
    }
    private void Drop(Vector2 enemyPos)
    {
        bool shouldDropCoin = Random.Range(0f,101f) <= coinDropChance;

        Dropables gojb = shouldDropCoin ? coinPool.Get() : XPPool.Get();
        gojb.transform.position = enemyPos;

        TryDropChest(enemyPos);
    }

    private void TryDropChest(Vector2 enemyPos)
    {
        bool shouldSpawnChest = Random.Range(0f,101f) <= chestDropChance;
        if(!shouldSpawnChest) return;

        Instantiate(chest,enemyPos,Quaternion.identity,transform);
    }
    private void ReleaseXP(XP XP) => XPPool.Release(XP);
    private void ReleaseCoins(Coins Coins) => coinPool.Release(Coins);

    public void updateStat(PlayerStatsManager playerStatsManager)
    {
        float Luck = playerStatsManager.GetStatsValue(Stats.Luck)/100;
        coinDropChance = coinDropChance * (1 + Luck);
        chestDropChance = chestDropChance * (1 + Luck);
    }
}
