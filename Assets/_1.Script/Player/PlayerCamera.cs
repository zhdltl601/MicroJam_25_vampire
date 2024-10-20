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
        [SerializeField] private float tValue = 0.2f;
        private CinemachineImpulseSource _source;
        private Vector3 initialPosition;
        public void Init(Player _player)
        {
            Player.EventPlayerDamaged += HandleOnDamaged;
            _source = GetComponent<CinemachineImpulseSource>();
            initialPosition = transform.position;
            print("Player Camera Init");
        }
        public void Dispose(Player _player)
        {

        }
        private void HandleOnDamaged()
        {

        }

        private void Update()
        {
            float t = tValue;
            Vector3 targetPos = transform.position;
            targetPos.y = Player.Instance.GetPlayerTransform().position.y;
            transform.position = Vector3.Lerp(initialPosition, targetPos, t);
        }
        public void CameraShake(float amount)
        {
            _source.m_DefaultVelocity = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            _source.GenerateImpulse(amount);
        }


    }
}
