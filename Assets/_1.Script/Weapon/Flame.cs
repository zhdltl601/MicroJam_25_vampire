using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    public LayerMask whatIsTarget;
    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        print(other);
        if (other.TryGetComponent(out Human hum))
        {
            hum.OnCollected();  
        }
        if (other.TryGetComponent(out BossHealth health))
        {
            Player.Instance.AddFuel(0.1f);
            health.GetDamage(0.05f);

        }
        Destroy(gameObject); // ÃÑ¾ËÀ» ÆÄ±«
    }
}
