using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Game
{
    public enum ObstacleType
    {
        Rotate,
        None,
    }
    public class Obstacle : MonoBehaviour
    {
        public ObstacleType type;
        public float speed;
        public LayerMask whatIsTarget;
        protected virtual void Start()
        {
            if (type == ObstacleType.Rotate)
            {
                transform.DORotate(new Vector3(0, 0, 360), 3f, RotateMode.FastBeyond360)
                    .SetLoops(-1, LoopType.Incremental)
                    .SetEase(Ease.Linear);
            }
        }

        private void Update()
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;


        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((whatIsTarget & (1 << other.gameObject.layer)) != 0)
            {
                Player.Instance.TakeDamage(1);
                print(gameObject);
            }
        }
    }
}

