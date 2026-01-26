using System.Collections;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{   
    [Header("Follow Target")]
    public Transform player;
    public Vector3 offset;

    [Header("Shake Settings")]
    public float duration = 0.2f;   
    public float magnitude = 0.3f;  

    private float timer;
    

    void Awake()
    {
        Player.onTakeDamge +=ActivateShake;
    }

    public void ActivateShake() 
    {
        timer = duration;
    }

    void LateUpdate() 
    {
        if (player == null) return;

        Vector3 targetPos = player.position + offset;

        if (timer > 0) 
        {
            transform.position = targetPos + (Vector3)Random.insideUnitCircle * magnitude;
            timer -= Time.deltaTime;
        }
        else 
        {
            transform.position = targetPos;
        }
    }
}
