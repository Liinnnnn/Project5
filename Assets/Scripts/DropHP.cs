using System;
using Unity.Mathematics;
using UnityEngine;

public class DropHP : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject HP;
    void Start()
    {
        Enemy.onDying += DropHealth;
    }
    void OnDestroy()
    {
        Enemy.onDying -=DropHealth;
    }
    private void DropHealth(Vector2 enemyPos)
    {
        Instantiate(HP,enemyPos,quaternion.identity,transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
