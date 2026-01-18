using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CircleCollider2D range;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectibles collectibles))
        {
            if (!collision.IsTouching(range))
            {
                return;
            }
            collectibles.Collect(GetComponent<Player>());
        }
    }
}
