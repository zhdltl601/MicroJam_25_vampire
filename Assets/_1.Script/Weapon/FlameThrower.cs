using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class FlameThrower : MonoBehaviour, IPlayerComponent
    {
        [SerializeField] private ParticleSystem _fire;
        [SerializeField] private ParticleSystem _smoke;
        
        private Camera cam;

        public void Init(Player _player)
        {

        }

        private void Awake()
        {
            cam = Camera.main;
        }
    
        private void Update()
        {
           
        }

        public void Fire()
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            print(mousePos);
            Vector3 direction = mousePos - transform.position;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            transform.rotation = Quaternion.Euler(0, 0, angle);
            
            _fire.Play();
            //_smoke.Play();

        }
    }
    
}
