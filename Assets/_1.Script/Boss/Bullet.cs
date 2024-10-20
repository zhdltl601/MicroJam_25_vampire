using System;
using UnityEngine;

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
        //Destroy(gameObject);
    }
}