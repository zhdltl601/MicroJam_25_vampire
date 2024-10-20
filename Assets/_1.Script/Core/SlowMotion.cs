using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SlowMotion : MonoBehaviour
{
    [SerializeField] private float startValue;
    [SerializeField] private float endValue;
    
    [SerializeField] private float duration;
    [SerializeField] private float coolDown;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SlowMotionStart(startValue,endValue, duration, coolDown);
        }
    }


    public void SlowMotionStart(float startValue,float endValue , float duration , float coolDown)
    {
        StartCoroutine(ISlowCoroutine(startValue, endValue,  duration , coolDown));
    }
    
    private IEnumerator ISlowCoroutine(float startValue, float endValue,float duration, float coolDown)
    {
        Time.timeScale = startValue;
        float initialTimeScale = Time.timeScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Time.timeScale = Mathf.Lerp(initialTimeScale, endValue, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;  
        }

        Time.timeScale = endValue;

        yield return new WaitForSecondsRealtime(coolDown);
        
        Time.timeScale = 1f;
    }
}