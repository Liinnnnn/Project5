using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Animator animator;
    [Header("Weapon Properties")]
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float range = 10f;
    [SerializeField] protected float attackDelay = 2f; 
    protected float attackTimer ;
    [SerializeField] protected LayerMask enemyLayer;
    [SerializeField] protected float aimLerp;

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
  
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
