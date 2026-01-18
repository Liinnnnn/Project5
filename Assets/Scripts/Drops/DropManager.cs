using UnityEngine;
using UnityEngine.Pool;

public class DropManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Hp HP;
    [SerializeField] private Coins coin;
    [SerializeField] private Chest chest;
    [Header("Setting")]
    [SerializeField][Range(0,100)] private int coinDropChance;
    [SerializeField][Range(0,100)] private int chestDropChance;

    private ObjectPool<Hp> hpPool; 
    private ObjectPool<Coins> coinPool; 
    void Start()
    {
        Enemy.onDying += Drop;
        hpPool = new ObjectPool<Hp>(hpCreateFunc,hpActionOnGet,hpActionOnRelease,hpActionOnDestroy);
        coinPool = new ObjectPool<Coins>(coinCreateFunc,coinActionOnGet,coinActionOnRelease,coinActionOnDestroy);
        Hp.onCollected += ReleaseHp;
        Coins.onCollected += ReleaseCoins;
    }
    private Hp hpCreateFunc() =>Instantiate(HP, transform);
    private void hpActionOnGet(Hp hp) => hp.gameObject.SetActive(true);
    private void hpActionOnRelease(Hp hp) => hp.gameObject.SetActive(false);
    private void hpActionOnDestroy(Hp hp) => Destroy(hp.gameObject);
    private Coins coinCreateFunc() =>Instantiate(coin, transform);
    private void coinActionOnGet(Coins Coin) => Coin.gameObject.SetActive(true);
    private void coinActionOnRelease(Coins Coin) => Coin.gameObject.SetActive(false);
    private void coinActionOnDestroy(Coins Coin) => Destroy(Coin.gameObject);
    void OnDestroy()
    {
        Enemy.onDying -=Drop;
        Hp.onCollected -= ReleaseHp;
        Coins.onCollected -= ReleaseCoins;
    }
    private void Drop(Vector2 enemyPos)
    {
        bool shouldDropCoin = Random.Range(0,101) <= coinDropChance;

        Dropables gojb = shouldDropCoin ? coinPool.Get() : hpPool.Get();
        gojb.transform.position = enemyPos;

        TryDropChest(enemyPos);
    }

    private void TryDropChest(Vector2 enemyPos)
    {
        bool shouldSpawnChest = Random.Range(0,101) <= chestDropChance;
        if(!shouldSpawnChest) return;

        Instantiate(chest,enemyPos,Quaternion.identity,transform);
    }
    private void ReleaseHp(Hp hp) => hpPool.Release(hp);
    private void ReleaseCoins(Coins Coins) => coinPool.Release(Coins);
}
