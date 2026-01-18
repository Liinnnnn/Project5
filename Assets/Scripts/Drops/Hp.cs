using System;
using System.Collections;
using UnityEngine;

public class Hp : Dropables
{
    public static event Action<Hp> onCollected; 
    protected override void Collected()
    {
        onCollected?.Invoke(this);
    }
}
