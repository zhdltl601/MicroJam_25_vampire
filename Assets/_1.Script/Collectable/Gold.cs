using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Gold : Collectable
    {
        private SpriteRenderer spriteRenderer;
        public AudioClip ac;
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public override void OnCollected()
        {
            GameManager.Instance.AddScore(1);
            //AudioManager.Instance.PlayOneShot(ac);
            DOVirtual.Float(1, 0, 0.1f, (value) =>
            {
                Color result = spriteRenderer.color;
                result.a = value;
                spriteRenderer.color = result;
            }).OnComplete(() => 
            { 
                print("Dele");
                Destroy(gameObject);
            });
        }
    
    }
}
