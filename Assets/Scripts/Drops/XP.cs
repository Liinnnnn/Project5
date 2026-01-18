using System;
using System.Collections;
using UnityEngine;

public class XP : Dropables
{
    public static event Action<XP> onCollected; 
    protected override void Collected()
    {
        onCollected?.Invoke(this);
    }
}
