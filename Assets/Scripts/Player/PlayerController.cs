using UnityEngine;

public class PlayerController : MonoBehaviour,IPlayerStats
{
    public DynamicJoystick joystick;
    private float speed;
    [SerializeField] private float BaseSpeed;
    
    private Rigidbody2D rb; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick == null) return;
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.linearVelocity = movement * speed;
        Flip(horizontalInput);
    }
    
    private void Flip(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void updateStat(PlayerStatsManager playerStatsManager)
    {
        float moveSpeedMultiplier = playerStatsManager.GetStatsValue(Stats.MoveSpeed)/100;
        speed = BaseSpeed * (1 + moveSpeedMultiplier);
    }
}

