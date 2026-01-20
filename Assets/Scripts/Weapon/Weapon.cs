using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour,IPlayerStats
{
    [field: SerializeField] public WeaponDataSO weaponData{get;private set;}
    protected Animator animator;
    [Header("Weapon Properties")]
    [SerializeField] protected float damage;
    [SerializeField] protected float critChance;
    [SerializeField] protected float critDamageMult;
    [SerializeField] protected float range = 10f;
    [SerializeField] protected float attackDelay = 2f; 
    protected float attackTimer ;
    [SerializeField] protected LayerMask enemyLayer;
    [SerializeField] protected float aimLerp;
    [Header("LEVEL")]
    [field: SerializeField] public float level {get;set;}

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    protected Enemy GetClosestEnemy()
    {
        Enemy closestEnemy = null;
        // Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude,FindObjectsSortMode.None);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);

        if (enemies.Length <= 0)
        {
            transform.up = Vector3.up;
            return null;
        }
        float minDistance = range;

        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy e = enemies[i].GetComponent<Enemy>();
            float distance = Vector2.Distance(transform.position, e.transform.position);
            if (distance < minDistance)
            {
                closestEnemy = e;
                minDistance = distance;
            }
        }
        
        return closestEnemy;
    }
    protected float getDamage(out bool isCrits)
    {
        isCrits = false;
        if (UnityEngine.Random.Range(0f,100f) <= critChance)
        {
            Debug.Log("Crits" + damage * critDamageMult);
            return damage * critDamageMult;
        }
        return damage;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    public abstract void updateStat(PlayerStatsManager playerStatsManager);
    protected void ConfigureStats()
    {
        float multiplier = 1 + level/10;
        damage = weaponData.getStats(Stats.Attack ) * multiplier;
        attackDelay = 1f / (weaponData.getStats(Stats.AttackSpeed) * multiplier);
        critChance = weaponData.getStats(Stats.CritChance) * multiplier;
        critDamageMult = weaponData.getStats(Stats.CritDamage) * multiplier;
        if(weaponData.weapon.GetType() == typeof(RangedWeapon))
        {
            range = weaponData.getStats(Stats.Range) * multiplier;
        }else
        {
            range = weaponData.getStats(Stats.Range);
        }
    }
}
