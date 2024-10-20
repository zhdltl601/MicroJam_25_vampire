using System;
using System.Collections;
using System.Drawing;
using System.Net.NetworkInformation;
using DG.Tweening;
using Game;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    [SerializeField] private RectTransform bossHealthTrm;
    [SerializeField] private Transform firePos;
    [SerializeField] private Bullet bullet;

    [SerializeField] private GameObject[] waringPoints;
    [SerializeField] private int[] yOffset = { 4, 0, -4 };
    
    private void Start()
    {
        
        DOVirtual.DelayedCall(1 , () =>
        {
            bossHealthTrm.DOAnchorPosY(-450, 3f).SetEase(Ease.InSine);

            StartCoroutine(PointAttack(10 , 20)) ;

            //StartCoroutine(ArcShot(30,0.2f));
        });
    }

        
    private IEnumerator ArcShot(int count, float delayTime)
    {
        for (int j = 0; j < count; j++)
        {
            float angle = -30f;
            float angleStep = 30f; 
            float bulletSpeed = 7f;

            for (int i = 0; i < 3; i++) 
            {
                // 총알 생성
                Bullet newBullet = Instantiate(bullet, firePos.position, Quaternion.identity);
                
                float bulletDirX = -1f;
                float bulletDirY = Mathf.Sin(angle * Mathf.Deg2Rad); 
            
                Vector2 bulletMoveVector = new Vector2(bulletDirX, bulletDirY);
                newBullet.GetComponent<Rigidbody2D>().velocity = bulletMoveVector * bulletSpeed; 

                // 각도 업데이트
                angle += angleStep; 
            }

            yield return new WaitForSeconds(delayTime);
        }
    }

    private IEnumerator PointAttack(int minCount, int maxCount)
    {
        yield return transform.DOMoveX(transform.position.x - 5, 2f).WaitForCompletion();
    
        int randomIndex = Random.Range(0 , waringPoints.Length);
        print(randomIndex);
        
        
        for (int i = 0; i < 20; i++)
        {
            waringPoints[randomIndex].SetActive(!waringPoints[randomIndex].activeSelf);
            yield return new WaitForSeconds(0.1f); 
        }
        
        for (int i = 0; i < 50; i++)
        {
            Bullet newBullet = Instantiate(bullet, new Vector3(transform.position.x,  yOffset[randomIndex], 0), Quaternion.identity);
            float bulletDirX = -1f;
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletDirX * 5, 0); // 속도 설정

            yield return new WaitForSeconds(0.1f);
        }
        
    }
    
    public void Initialize(Transform trm)
    {
        transform.DOMove(trm.position , 2);
    }
    
    
    
    
}
