using System;
using UnityEngine;
using UnityEngine.Pool;

public class RangedAttack : MonoBehaviour
{
    [Header("Ranged Attack Settings")]
    private Player player;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float attackRate;
    private float attackDelay;
    private float attackTimer;
    [Header("Projectile Settings")]
    [SerializeField] private Bullet projectile;
    [SerializeField] private Transform shootPoint;
    private ObjectPool<Bullet> bulletPool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        attackDelay = 1f / attackRate;
        bulletPool = new ObjectPool<Bullet>(createFunc,actionOnGet,actionOnRelease,actionOnDestroy);

    }
    private Bullet createFunc()
    {
        Bullet bullet = Instantiate(projectile, transform.position, Quaternion.identity);
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
    
    public void AimTowardsPlayer()
    {
        TryShooting();
    }
    public void releaseBullet(Bullet bullet)
    {
        bulletPool.Release(bullet);
    }
    private void TryShooting()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDelay)
        {
            // player.TakeDamage(damage);
            ShootProjectile();
            attackTimer = 0f;
        } 
    }
    Vector2 gizmoDirection;
    private void ShootProjectile()
    {
        Vector2 direction = (player.getCenter() - (Vector2)shootPoint.position).normalized;  
        Flip(direction);       
        Bullet bullet = bulletPool.Get();
        bullet.Shoot(damage, direction);
        gizmoDirection = direction;
        Debug.Log("Ranged attack: Shot projectile towards player.");
    }
    public void Flip(Vector2 direction)
    {
        if (direction.x > 0) {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x),transform.localScale.y);
        } 
        else if (direction.x < 0) {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x),transform.localScale.y);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(shootPoint.position, (Vector2)shootPoint.position + gizmoDirection * 8f);
    }
}
