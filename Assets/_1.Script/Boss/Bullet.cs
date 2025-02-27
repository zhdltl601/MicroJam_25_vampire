﻿using System;
using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        private float timer;
        [SerializeField] private LayerMask whatIsTarget;

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((whatIsTarget & (1 << other.gameObject.layer)) != 0)
            {
                Player.Instance.TakeDamage(5);
                Destroy(gameObject); // 총알을 파괴
            }
        }
    }

}
