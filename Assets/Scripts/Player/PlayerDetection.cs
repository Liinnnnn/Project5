using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CircleCollider2D range;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectibles collectibles))
        {
            if (!collision.IsTouching(range))
            {
                return;
            }
            if (collectibles is not Chest)
            {
                collectibles.Collect(GetComponent<Player>());
            }
        }
    }
}
