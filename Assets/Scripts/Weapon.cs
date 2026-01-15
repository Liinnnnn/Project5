using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    enum WeaponState
    {
        Idle,
        Attacking
    }
    private WeaponState State ;
    private List<Enemy> damagedEnemies = new List<Enemy>();
    [Header("References")]
    [SerializeField] private Transform HitPoint;
    [SerializeField] private float hitRadius = 0.2f;
    private Animator animator;
    [Header("Weapon Properties")]
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 10f;
    [SerializeField] private float attackDelay = 2f; 
    private float attackTimer ;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float aimLerp;

    void Start()
    {
        animator = GetComponent<Animator>();   
        State = WeaponState.Idle;
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

    private void Wait()
    {
        attackTimer += Time.deltaTime;
    }
    private Enemy GetClosestEnemy()
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
    private void AttackEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(HitPoint.position, hitRadius, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy e = enemy.GetComponent<Enemy>();
            if (!damagedEnemies.Contains(e))
            {
                e.TakeDamage(damage);
                damagedEnemies.Add(e);
            }
            
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(HitPoint.position, hitRadius);
    }
}
