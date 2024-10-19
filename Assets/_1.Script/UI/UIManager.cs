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
    }

}
