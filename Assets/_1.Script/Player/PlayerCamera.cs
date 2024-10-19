using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerCamera : MonoBehaviour, IPlayerComponent
    {
        public void Init(Player _player)
        {
            print("Player Camera Init");
        }
        public void CameraShake(float amount)
        {

        }
    }
}
