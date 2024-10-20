using System;
using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        private float timer;
        [SerializeField] private LayerMask whatIsEnemy;


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
            if ((whatIsEnemy & (1 << other.gameObject.layer)) != 0)
            {
                Player.Instance.TakeDamage(1);
                Destroy(gameObject); // 총알을 파괴
            }
        }
    }
}
