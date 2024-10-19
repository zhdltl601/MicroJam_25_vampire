using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Lumin;

public class Scrolling : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float endValue;
    
    private void Update()
    {
        transform.position -= new Vector3(speed , 0 , 0) * Time.deltaTime;

        if (transform.position.x <= -endValue)
        {
            transform.position = new Vector3(endValue,0,0);
        }
    }
}
