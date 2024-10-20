using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour, ICollectable
{
    public abstract void OnCollected();
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollected();
    }

}
