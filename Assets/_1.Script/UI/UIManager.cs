using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private TextMeshProUGUI fuelMeterTM;
        [SerializeField] private TextMeshProUGUI scoreTM;
        private void Start()
        {
            Player.Instance.EventFuelChange += HandleOnFuelChange;
            GameManager.EventScoreChange += HandleOnScoreChange;
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            Player.Instance.EventFuelChange -= HandleOnFuelChange;
            GameManager.EventScoreChange -= HandleOnScoreChange;
        }
        private void HandleOnFuelChange(float obj)
        {
            fuelMeterTM.text = $"Fuel Meter : {obj}";
        }
        private void HandleOnScoreChange(int score)
        {
            scoreTM.text     = $"Score      : {score}";
        }
    }

}
