using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CircleCollider2D playerCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Hp hp))
        {
            if (!collision.IsTouching(playerCollider))
            {
                return;
            }
            hp.Collect(GetComponent<Player>());
        }
    }
}
