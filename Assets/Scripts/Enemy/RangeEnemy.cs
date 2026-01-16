using System;
using UnityEngine;
using UnityEngine.Pool;

public class RangeEnemy : MonoBehaviour
{
    private Player player;
    private RangedAttack rangedAttack;
    [Header("General Settings")]
    [SerializeField] private float speed = 3.0f;

    [Header("Ranged Enemy Settings")]
    [SerializeField] private float rangePlayerDetectionRange = 10f;
    [SerializeField] private Bullet projectile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        rangedAttack = GetComponent<RangedAttack>();

        if (player == null)
        {
            Debug.LogError("Player not found in the scene.");
            Destroy(gameObject);
        }
    }
    void Update()
    {
        ManageAttack();
    }
    private void ManageAttack()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= rangePlayerDetectionRange)
        {
            TryAttackPlayer();
        }else
        {
            MoveTowardsPlayer();
        }
    }
    private void TryAttackPlayer()
    {
        rangedAttack.AimTowardsPlayer();   
    }
   
    private void MoveTowardsPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rangedAttack.Flip(direction);
        Vector2 newPosition = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.position = newPosition;
    }
   
   
    void OnDrawGizmos()
    {
        Gizmos.color = Color.beige;
        Gizmos.DrawWireSphere(transform.position, rangePlayerDetectionRange);
    }
}
