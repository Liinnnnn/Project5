using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    private Player player;
    [Header("General Settings")]
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float playerDetectionRange = 5.0f;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float attackRate;
    [SerializeField] private Animator animator;
    
    private float attackDelay;
    private float attackTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        if (player == null)
        {
            Debug.LogError("Player not found in the scene.");
            Destroy(gameObject);
        }
        attackDelay = 1f / attackRate;
    }
    void Awake()
    {
        instance = this;
        
    }
    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        if (attackTimer >= attackDelay)
        {
            TryAttackPlayer();
        }
        else
        {
            WaitAttackDelay();
        }
    }
    private void TryAttackPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
    
        if (distanceToPlayer <= playerDetectionRange)
        {
            AttackPlayer();
        }            
    
    }
    private void WaitAttackDelay()
    {
        attackTimer += Time.deltaTime;
    }
    private void AttackPlayer()
    {
        animator.SetBool("Attack",true);
        player.TakeDamage(damage);   
        attackTimer = 0f;
       
    }
    private void MoveTowardsPlayer()
    {
        Vector2 direction = (player.getCenter() - (Vector2)transform.position).normalized;
        Vector2 newPosition = Vector2.MoveTowards(transform.position, player.getCenter(), speed * Time.deltaTime);
        if (direction.x > 0) {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x),transform.localScale.y);
        } 
        else if (direction.x < 0) {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x),transform.localScale.y);
        }
        transform.position = newPosition;
    }   

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerDetectionRange);
    }
   
}
