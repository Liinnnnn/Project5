using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DynamicJoystick joystick;
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.linearVelocity = movement * speed;
    }
}
