using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    [SerializeField] private RectTransform bossHealthTrm;
    private Transform bossTrm;
    
    [SerializeField] private Transform firePos;
    [SerializeField] private Bullet bullet;
    
    [SerializeField] private GameObject[] waringPoints;
    [SerializeField] private float[] yOffset = { 4, 0, -4 };

    private float timer = 0;
    private float attackTime = 3;
    private bool isAttacking;
    
    private void Start()
    {
        
        DOVirtual.DelayedCall(1 , () =>
        {
            bossHealthTrm.DOAnchorPosY(-450, 3f).SetEase(Ease.InSine);
        });
    }


    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > attackTime && isAttacking == false)
        {
            timer = 0;
            int attackType = Random.Range(0, 2);

            if (attackType == 0)
            {
                StartCoroutine(ArcShot(20 , 0.25f));
            }
            else if (attackType == 1)
            {
                StartCoroutine(PointAttack(10, 20));
            }
            
        }
        
        
    }

    private IEnumerator ArcShot(int count, float delayTime)
    {
        isAttacking = true;
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
        isAttacking = false;
    }

    private IEnumerator PointAttack(int minCount, int maxCount)
    {
        isAttacking = true;
        int randomIndex = Random.Range(0, waringPoints.Length);
    
        for (int i = 0; i < 20; i++)
        {
            waringPoints[randomIndex].SetActive(!waringPoints[randomIndex].activeSelf);
            yield return new WaitForSeconds(0.1f); 
        }
    
        yield return transform.DOMoveY(yOffset[randomIndex], 0.5f).WaitForCompletion();

        int randomBulletCount = Random.Range(minCount, maxCount);
    
        for (int i = 0; i < randomBulletCount; i++)
        {
            Bullet newBullet = Instantiate(bullet, new Vector3(firePos.position.x, firePos.position.y, 0), Quaternion.identity);
            float bulletDirX = -1f;
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletDirX * 5, 0); // 속도 설정
    
            yield return new WaitForSeconds(0.25f);
        }
        isAttacking = false;
    }

    
    public void Initialize(Transform trm)
    {
        bossTrm = trm;
        transform.DOMove(bossTrm.position, 2);
    }
       


}
