using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Extension;

namespace Game
{
    public class PlayerMovement : MonoBehaviour, IPlayerComponent
    {
        [Header("Serailized Memebers")]
        [SerializeField] private float jumpValue;
        [SerializeField] private float maxY;

        //private members
        private Rigidbody2D rigidBody;

        public void Jump(float force = 0)
        {
            if (force == 0) force = jumpValue;
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(transform.up * force, ForceMode2D.Impulse);
        }
        private void Update()
        {
            Vector3 clampedVector = transform.position;
            if (clampedVector.y > maxY)
                clampedVector.y = maxY;

            transform.position = clampedVector;
        }
        void IPlayerComponent.Init(Player _player)
        {
            rigidBody = this.GetComponentOrAdd<Rigidbody2D>();
            print("movement init");
        }

        public void Dispose(Player _player)
        {

        }
    }

}
