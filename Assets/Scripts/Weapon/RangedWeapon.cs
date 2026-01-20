using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool; 

public class RangedWeapon : Weapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Settings")]
    [SerializeField] private Bullet bulletPrebs;
    [SerializeField] private Transform shootPoint;
    private ObjectPool<Bullet> bulletPool ;
    void Start()
    {
        bulletPool = new ObjectPool<Bullet>(createFunc,actionOnGet,actionOnRelease,actionOnDestroy);
    }
     private Bullet createFunc()
    {
        Bullet bullet = Instantiate(bulletPrebs, transform.position, Quaternion.identity);
        bullet.Configure(this);
        return bullet;
    }
    private void actionOnGet(Bullet bullet)
    {
        bullet.transform.position = shootPoint.position;
        bullet.reload();
        bullet.gameObject.SetActive(true);
    }
    private void actionOnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
    private void actionOnDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
    public void releaseBullet(Bullet bullet)
    {
        if (!gameObject.activeSelf)
        {
            return;
        }
        bulletPool.Release(bullet);
    }
    // Update is called once per frame
    void Update()
    {
        AimToEnemy();
    }
    private void AimToEnemy()
    {
        Enemy closestEnemy = GetClosestEnemy();
        
        Vector2 targetDirection = Vector2.up;
        
        if (closestEnemy != null) {
            targetDirection = (closestEnemy.transform.position - transform.position).normalized;
            transform.up = Vector3.Lerp(transform.up, targetDirection, Time.deltaTime * aimLerp);
            ManageShooting();
            return;
        }else
        {
            transform.up = Vector3.Lerp(transform.up, targetDirection, Time.deltaTime * aimLerp);
        }
    }

    private void ManageShooting()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDelay)
        {
            ShootProjectile();
            attackTimer = 0f;
        } 
    }

    private void ShootProjectile()
    {
        float damage = getDamage(out bool crits);

        Bullet intancsezbullet = bulletPool.Get();
        intancsezbullet.Shoot(damage,transform.up);
    }

    public override void updateStat(PlayerStatsManager playerStatsManager)
    {
        Debug.Log(damage);
        ConfigureStats();

        attackDelay /= 1 + (playerStatsManager.GetStatsValue(Stats.AttackSpeed) / 100); 
        critChance = critChance * (1 + playerStatsManager.GetStatsValue(Stats.CritChance)/10);
        critDamageMult += playerStatsManager.GetStatsValue(Stats.CritDamage)/100;
        damage = damage * (1 + playerStatsManager.GetStatsValue(Stats.Attack)/100);
        range += playerStatsManager.GetStatsValue(Stats.Range);

        Debug.Log(damage);
        
    }
}
