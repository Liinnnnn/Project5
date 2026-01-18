using System;
using UnityEngine;

public class Chest : MonoBehaviour, ICollectibles
{
    public static event Action<Chest> onCollected;
    public void Collect(Player player)
    {
        onCollected?.Invoke(this);
        Destroy(gameObject);
    }
}
