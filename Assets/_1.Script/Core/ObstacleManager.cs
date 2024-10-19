using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> obstacleType;
    
    [SerializeField] private Transform spawnTrm;
    [SerializeField] private float spawnTime = 1.2f;
    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            timer = 0;

            GameObject newObstacle = Instantiate(obstacleType[Random.Range(0 , obstacleType.Count)] ,spawnTrm.position, Quaternion.identity);
        }

    }
}
