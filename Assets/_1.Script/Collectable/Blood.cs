using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class Blood : MonoBehaviour
    {
        private const float endTime = 1;

        private void Start()
        {
            StartCoroutine(CO_GotoPlayer());
        }
        private IEnumerator CO_GotoPlayer()
        {
            float timer = 0;
            Transform playerTrm = Player.Instance.GetPlayerPosition();
Vector3 toPlayerDir = transform.position - playerTrm.position;
            static float GetRnadomNumber()
            {
                return Random.Range(-180, 180);
            }
            Func<float> GRN = GetRnadomNumber;
            Vector3 objDir = new(0, 0, GRN());
            transform.rotation = Quaternion.Euler(objDir);

            Quaternion startRotation = transform.rotation;
            Vector3 startPosition = transform.position;
            while (timer <= endTime)
            {
                timer += Time.deltaTime;
                transform.SetPositionAndRotation(Vector3.Lerp(startPosition, playerTrm.position, timer / endTime), 
                    Quaternion.Lerp(startRotation, Quaternion.identity, timer / endTime));
                yield return null;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            
        }
    }

}
