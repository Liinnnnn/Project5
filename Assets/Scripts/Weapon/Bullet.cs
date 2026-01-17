using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private RangedWeapon rangedWeapon;
    [Header("Bullet Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask enemyMask;
    private Enemy target;
    void Start()
    {
        
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        StartCoroutine(backToPool());
    }
    public void reload()
    {
        rb.linearVelocity = Vector2.zero;
        target = null;
    }
    
    public void Configure(RangedWeapon rangedWeapon)
    {
        this.rangedWeapon = rangedWeapon;
    }
    public void Shoot(float damage,Vector2 dir)
    {
        this.damage = damage;
        transform.up = dir;
        rb.linearVelocity = dir * speed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (target != null)
        {
            return;
        }
        if (isEnemyMask(collision.gameObject.layer,enemyMask))
        {
            target = collision.gameObject.GetComponent<Enemy>();
            StopAllCoroutines();
            Attack(target);
            rangedWeapon.releaseBullet(this);
        }
    }

    private bool isEnemyMask(int layer, LayerMask enemyMask)
    {
        return (enemyMask.value & 1<< layer) !=0 ;
    }

    private void Attack(Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }
    private IEnumerator backToPool()
    {
        yield return new WaitForSeconds(5f);
        rangedWeapon.releaseBullet(this);
    }
}
