using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Extension
{
    public static class Extension
    {
        public static T GetComponentOrAdd<T>(this MonoBehaviour mono) where T : Component
        {
            T result = mono.GetComponent<T>();
            if (result == null)
            {
                Debug.LogWarning($"{typeof(T)}Component Not PreExisted, Adding default Component...");
                result = mono.gameObject.AddComponent<T>();
            }
            return result;
        }
    }

}