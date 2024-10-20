using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Human : Collectable
    {
        [SerializeField] private GameObject _prefabBlood;

        public override void OnCollected()
        {
            Instantiate(_prefabBlood, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
    }

}