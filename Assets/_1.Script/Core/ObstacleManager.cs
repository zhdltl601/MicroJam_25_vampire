using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class ObstacleManager : MonoBehaviour
    {
        public List<GameObject> obstacleType;

        [SerializeField] private Transform spawnTrm;
        [SerializeField] private Transform bossTrm;

        [SerializeField] private float spawnTime = 1.2f;
        private float timer = 0;
        private float bossTimer = 0;

        [Header("Boss info")]
        public bool isBossMode;
        [SerializeField] private GameObject[] bossList;

    private void Start()
    {
        //EnterBoss();
    }

        private void Update()
        {
            if (isBossMode == true) return;

            timer += Time.deltaTime;
            bossTimer += Time.deltaTime;

            if (timer >= spawnTime)
            {
                timer = 0;
                GameObject newObstacle = Instantiate(obstacleType[Random.Range(0, obstacleType.Count)], spawnTrm.position, Quaternion.identity);
            }

            if (bossTimer > 30)
            {
                timer = 0;
                bossTimer = 0;

                EnterBoss();
            }
        }

        public void EnterBoss()
        {
            isBossMode = true;
            GameObject newBoss = Instantiate(bossList[0], spawnTrm.position, Quaternion.identity);
            newBoss.GetComponent<Boss>().Initialize(bossTrm);
        }
    }

}
