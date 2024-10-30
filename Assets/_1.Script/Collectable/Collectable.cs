using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour, ICollectable
{
    public abstract void OnCollected();
    [SerializeField] private LayerMask whatIsTarget;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatIsTarget & (1 << collision.gameObject.layer)) != 0)
        {
            OnCollected();
        }
    }

}
