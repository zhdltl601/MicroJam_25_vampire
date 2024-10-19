using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Human : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabBlood;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameManager.Instance.AddFuel(2);
            Destroy(gameObject);
        }
    }

}