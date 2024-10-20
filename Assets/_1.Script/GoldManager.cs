using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private GameObject gold;
    [SerializeField] private Transform spawnTrm;

    private float timer = 0;
    
    private float triangleTimer = 0;
    private float TriangleTime = 5;
    private void Update()
    {
        triangleTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            timer = 0;
            Instantiate(gold , spawnTrm.position , Quaternion.identity);
        }
        
        
        if (triangleTimer > TriangleTime)
        {
            triangleTimer = 0;
            StartCoroutine(SpawnGoldInTriangle());
        }
    }

    private IEnumerator SpawnGoldInTriangle()
    {
        Vector3[] triangleVertices = new Vector3[3];
        float sideLength = 2.0f; // 삼각형의 변 길이

        // 삼각형의 세 꼭짓점 계산
        triangleVertices[0] = spawnTrm.position; // 첫 번째 꼭짓점
        triangleVertices[1] = spawnTrm.position + new Vector3(sideLength, 0, 0); // 두 번째 꼭짓점
        triangleVertices[2] = spawnTrm.position + new Vector3(sideLength / 2, Mathf.Sqrt(3) * sideLength / 2, 0); // 세 번째 꼭짓점

        foreach (var vertex in triangleVertices)
        {
            Instantiate(gold, vertex, Quaternion.identity);
            yield return new WaitForSeconds(1f); // 1초 간격으로 생성
        }
    }
}