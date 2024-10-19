using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health = 100;
    public event Action OnDeadEvent;
    public event Action<float> OnHitEvent;
        
    
    
    
    public void GetDamage(float damage)
    {
        health -= damage;

        OnHitEvent?.Invoke(health);
                        
        if (health <= 0)
        {
            OnDeadEvent?.Invoke();
        }
    }
    
    


}
