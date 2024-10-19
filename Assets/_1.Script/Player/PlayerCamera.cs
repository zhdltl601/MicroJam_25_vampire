using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class PlayerCamera : MonoBehaviour, IPlayerComponent
    {
        private CinemachineImpulseSource _source;

        private void Awake()
        {
            _source = GetComponent<CinemachineImpulseSource>();
        }

        public void Init(Player _player)
        {
            print("Player Camera Init");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                CameraShake(0.5f);
            }
        }

        public void CameraShake(float amount)
        {
            _source.m_DefaultVelocity = new Vector3(Random.Range(-0.2f,0.2f) , Random.Range(-0.2f , 0.2f) , Random.Range(-0.2f, 0.2f));
            _source.GenerateImpulse(amount);
        }
    }
}
