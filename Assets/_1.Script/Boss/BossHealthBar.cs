using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider easingHealthBar;

    private BossHealth _bossHealth;

    private float lastHitTime;
    private bool available = false;

    private void Start()
    {
        _bossHealth = GetComponentInParent<BossHealth>();
        _bossHealth.OnHitEvent += HandleHitEvent;
    }

    private void OnDestroy()
    {
        _bossHealth.OnHitEvent -= HandleHitEvent;
    }
    private void Update()
    {
        if (available && lastHitTime + 2 < Time.time)
        {
            float newHealth = healthBar.value;
            SetHealthBar(newHealth);
        }
    }
    private void HandleHitEvent(float health)
    {
        healthBar.value = health;
        lastHitTime = Time.time;
    }

    public void SetHealthBar(float health)
    {
       
        
        if (healthBar.value != easingHealthBar.value)
        {
            DOVirtual.Float(easingHealthBar.value, healthBar.value, 1, value => 
            {
                easingHealthBar.value = value;
            }).SetEase(Ease.InSine);
        }
    }
    
    
    
}
