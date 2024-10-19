using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private float fuelReduceMultiplier;
        [SerializeField] private float fuelMeter;
        public float GetFuel { get => fuelMeter; }
        private void Update()
        {
            fuelMeter -= Time.deltaTime * fuelReduceMultiplier;
        }
    }

}