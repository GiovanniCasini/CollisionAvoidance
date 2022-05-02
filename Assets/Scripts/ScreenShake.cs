using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance;
    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;
    private float rotationMultiplier /*= 15f*/;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;
            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            float zAmount = Random.Range(0f, 1f) * shakePower * 1.5f;

            transform.position += new Vector3(xAmount, yAmount, zAmount);
            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
    }

    public void StartShake(float length, float power, float rotation)
    {
        shakeTimeRemaining = length;
        shakePower = power;
        rotationMultiplier = rotation;

        shakeFadeTime = power / length;
        shakeRotation = power * rotationMultiplier;
    }
}
