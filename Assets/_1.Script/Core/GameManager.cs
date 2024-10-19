using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private float fuelReduceMultiplier;
        [SerializeField] private float fuelMeter;
        private float speedMeter;
        private int score;
        public static event Action<float> EventFuelChange;
        public static event Action<int> EventScoreChange;
        public static event Action EventPlayerDead;

        protected override void Awake()
        {
            base.Awake();
            StartCoroutine(CO_Score());
            EventFuelChange += CalculateFuel;
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            StopAllCoroutines();
            EventFuelChange -= CalculateFuel;
        }
        public void AddFuel(float value)
        {
            fuelMeter += value;
            EventFuelChange?.Invoke(fuelMeter);
        }
        public void AddScore(int value)
        {
            score += value;
            EventScoreChange?.Invoke(score);
        }
        private void Update()
        {
            bool isFuelIncreassing = false;
            speedMeter += isFuelIncreassing ? Time.deltaTime : -Time.deltaTime;
        }
        private IEnumerator CO_Score()
        {
            while (!Player.IsPlayerDead)
            {
                yield return null;
                fuelMeter -= fuelReduceMultiplier * Time.deltaTime;
                EventFuelChange?.Invoke(fuelMeter);
            }
        }
        private void CalculateFuel(float fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                fuelMeter = 0;
                EventPlayerDead?.Invoke();
                print("Dead");
            }
        }
    }

}