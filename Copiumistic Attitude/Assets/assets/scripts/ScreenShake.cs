using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float screenShakeDuration;
    [SerializeField] private AnimationCurve screenShakeCurve;
    
    public IEnumerator ScreenShakeRoutine()
    {
        Debug.unityLogger.Log("ScreenShakeRoutine");
        float currentTime = 0;
        Vector3 originalPos = transform.position;

        while (currentTime < screenShakeDuration)
        {
            Vector2 randomOfsset = transform.position = Random.insideUnitCircle * screenShakeCurve.Evaluate(currentTime / screenShakeDuration);
            
            transform.position = originalPos + new  Vector3(randomOfsset.x, randomOfsset.y, 0);
            
            currentTime += Time.deltaTime;
            Debug.unityLogger.Log(transform.position.ToString());

            yield return null;
        }
        
        transform.position = originalPos;
        Debug.unityLogger.Log("ScreenShakeRoutine Ended");

    }
}
