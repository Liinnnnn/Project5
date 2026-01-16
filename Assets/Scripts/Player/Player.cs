using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float MaxHealth = 100f;
    private float health ;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Collider2D playerCollider;
    void Start()
    {
        health = MaxHealth;
        healthBar.value = 1;
        hpText.text = health.ToString() + " / " + MaxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Player took " + damage + " damage.");
        health -= damage;
        changeHealthBar();
        if (health <= 0)
        {
            Die();
        }
    }
    private void changeHealthBar()
    {
        healthBar.value = health / MaxHealth;
        hpText.text = health.ToString() + " / " + MaxHealth.ToString();
    }   
    private void Die()
    {
        Debug.Log("Player died.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public Vector2 getCenter()
    {
        return (Vector2)transform.position + playerCollider.offset;
    }
}
