using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private int score;

        public static event Action<int> EventScoreChange;
        public void AddScore(int value)
        {
            score += value;
            EventScoreChange?.Invoke(score);
        }
        public void SlowMotion(float duration)
        {

        }

    }

}