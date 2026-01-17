using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 20f;
    [SerializeField] private ParticleSystem deathEffect;
    private float health;
    public static event Action<Vector2> onDying;
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
        onDying?.Invoke(transform.position);  
        Destroy(this.gameObject);    
    }   
}
