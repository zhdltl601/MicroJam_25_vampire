using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Upgrade : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    
    }
}
