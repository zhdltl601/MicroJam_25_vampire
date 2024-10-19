using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private TextMeshProUGUI fuelMeterTM;
        [SerializeField] private TextMeshProUGUI scoreTM;
        
        [Header("BloodScreen")]
        [SerializeField] private Image bloodScreen;
        [SerializeField] private float bloodScreenDuration;
        private float targetBlood = 0.4f;

        
        
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
        
        [ContextMenu("지건")]
        private void BloodScreen()
        {
            bloodScreen.DOFade(targetBlood , bloodScreenDuration).OnComplete(() =>
            {
                bloodScreen.DOFade(0, bloodScreenDuration);
            });


        }
        
    }

}
