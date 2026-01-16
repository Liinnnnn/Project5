using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 20f;
    [SerializeField] private ParticleSystem deathEffect;
    private float health;


    void Start()
    {
        health = MaxHealth;
        
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Enemy took " + damage + " damage.");
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Enemy died.");
            Death();
        }
    }
    
    private void Death()
    {
        deathEffect.Play();
        deathEffect.transform.SetParent(null);  
        Destroy(this.gameObject);    
    }   
}
