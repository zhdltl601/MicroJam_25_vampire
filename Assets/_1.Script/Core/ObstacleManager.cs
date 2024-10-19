using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> obstacleType;
    
    [SerializeField] private Transform spawnTrm;
    [SerializeField] private float spawnTime = 1.2f;
    private float timer = 0;
    private float bossTimer = 0;
    
    [Header("Boss info")]
    public bool isBossMode;
    [SerializeField] private GameObject[] bossList;
    
    private void Update()
    {
        if(isBossMode == true)return;
        
        timer += Time.deltaTime;
        bossTimer += Time.deltaTime;
        
        if (timer >= spawnTime)
        {
            timer = 0;
            GameObject newObstacle = Instantiate(obstacleType[Random.Range(0 , obstacleType.Count)] ,spawnTrm.position, Quaternion.identity);
        }

        if (bossTimer > 30)
        {
            timer = 0;
            bossTimer = 0;
            
            EnterBoss();
        }
    }
    
    [ContextMenu("시작")]
    public void EnterBoss()
    {
        isBossMode = true;
        Instantiate(bossList[0] , transform.position , Quaternion.identity);
    }
}
