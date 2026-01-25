using System;
using UnityEngine;

public class Diamond :  Dropables
{
     public static event Action<Diamond> onCollected; 
    protected override void Collected()
    {
        onCollected?.Invoke(this);
    }
}
