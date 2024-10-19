using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private ParticleSystem _smoke;
    
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
    
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        
        if (Input.GetMouseButton(0))
        {
            _fire.Play();
            //_smoke.Play();
        }
    }
}
