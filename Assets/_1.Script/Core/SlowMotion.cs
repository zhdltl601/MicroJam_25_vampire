using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{

    public void SlowMotionStart(float target , float duration , float coolDown)
    {
        StartCoroutine(ISlowCoroutine(target , duration , coolDown));
    }
    
    private IEnumerator ISlowCoroutine(float targetValue, float duration, float coolDown)
    {
        float initialTimeScale = Time.timeScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Time.timeScale = Mathf.Lerp(initialTimeScale, targetValue, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;  
        }

        Time.timeScale = targetValue;

        yield return new WaitForSecondsRealtime(coolDown);
        Time.timeScale = 1f;
    }
}