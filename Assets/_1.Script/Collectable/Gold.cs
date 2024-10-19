using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Gold : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    
    }
}
