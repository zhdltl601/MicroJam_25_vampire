using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class Blood : Collectable
    {
        private const float endTime = 0.8f;
        private void Start()
        {
            StartCoroutine(CO_GotoPlayer());
        }
        private IEnumerator CO_GotoPlayer()
        {
            float timer = 0;
            Transform playerTrm = Player.Instance.GetPlayerTransform();
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
        public override void OnCollected()
        {
            Player.Instance.AddFuel(10);
            DOVirtual.Float(1, 0, 0.1f, (v3) =>
            {
                Vector3 result = new Vector3(v3, v3, v3);
                result.z = 1;
                transform.localScale = result;
            }).OnComplete(() => { Destroy(gameObject);print("delete"); });
        }
    }

}
