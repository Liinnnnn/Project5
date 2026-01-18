using System;
using UnityEngine;

public class Coins : Dropables
{
    public static event Action<Coins> onCollected; 
    protected override void Collected()
    {
        onCollected?.Invoke(this);
    }
}
