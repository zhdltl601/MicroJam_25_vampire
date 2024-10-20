using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Human : MonoBehaviour, ICollectable
    {
        [SerializeField] private GameObject _prefabBlood;

        public void OnCollected()
        {
            Player.Instance.AddFuel(10);
            Destroy(gameObject);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollected();
        }
    }

}