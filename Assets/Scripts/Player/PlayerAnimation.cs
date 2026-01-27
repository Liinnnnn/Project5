using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(rb.linearVelocity.magnitude < 0.001f)
        {
            animator.Play("Idle");
        }else animator.Play("Move");
    }
}
