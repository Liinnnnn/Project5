using UnityEngine;
using System.Collections.Generic;

public class MeleeWeapon : Weapon
{
    enum WeaponState
    {
        Idle,
        Attacking
    }
    private List<Enemy> damagedEnemies = new List<Enemy>();
    private WeaponState State ;
    [Header("References")]
    [SerializeField] private Transform HitPoint;
    [SerializeField] private PolygonCollider2D weaponCollider;
    void Start()
    {
        State = WeaponState.Idle;
        animator = gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case WeaponState.Idle:
                AimToEnemy();
                break;
            case WeaponState.Attacking:
                // HandleAttackingState();
                Attacking();
                break;
        }
    }
    
    private void AimToEnemy()
    {
        Enemy closestEnemy = GetClosestEnemy();
        
        Vector2 targetDirection = Vector2.up;
        
        if (closestEnemy != null) {
            ManageAttack();
            targetDirection = (closestEnemy.transform.position - transform.position).normalized;
        }
        transform.up = Vector3.Lerp(transform.up, targetDirection, Time.deltaTime * aimLerp);

        Wait();
    }
    private void ManageAttack()
    {
        if (attackTimer >= attackDelay)
        {
            attackTimer = 0f;
            StartAttack();
        }
    }   
    private void StartAttack()
    {
        State = WeaponState.Attacking;
        animator.Play("Attack");
    }
    private void Attacking()
    {
        AttackEnemy();
    }
    public void EndAttack()
    {
        State = WeaponState.Idle;
        damagedEnemies.Clear();
    }
    private void Wait()
    {
        attackTimer += Time.deltaTime;
    }
      private void AttackEnemy()
    {
        // Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(HitPoint.position, hitRadius, enemyLayer);
        Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(weaponCollider.bounds.min, 
        weaponCollider.bounds.max, 
        enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy e = enemy.GetComponent<Enemy>();
            if (!damagedEnemies.Contains(e))
            {
                float damage = getDamage(out bool crits);
                e.TakeDamage(damage);
                damagedEnemies.Add(e);
            }
            
        }
    }

    public override void updateStat(PlayerStatsManager playerStatsManager)
    {
        Debug.Log(damage);
        ConfigureStats();

        attackDelay /= 1 + (playerStatsManager.GetStatsValue(Stats.AttackSpeed) / 100); 
        critChance += playerStatsManager.GetStatsValue(Stats.CritChance)/100;
        critDamageMult += 1 + playerStatsManager.GetStatsValue(Stats.CritDamage)/100;
        damage += damage * (1 + playerStatsManager.GetStatsValue(Stats.Attack)/100);
        Debug.Log(damage);
    }
}
