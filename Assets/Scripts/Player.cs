using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float health = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Player took " + damage + " damage.");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player died.");
    }
}
