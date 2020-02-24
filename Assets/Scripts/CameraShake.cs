using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float softShakePower = 1f;
    public float softShakeTime = .2f;
    public float hardShakePower = 1f;
    public float hardShakeTime = .2f;

    public bool isShaking;
    public bool isHardShake;

    Vector3 originalPos;
    float shakeTimer;

    void Start() {
        isShaking = false;
        isHardShake = false;
        originalPos = transform.position;
        shakeTimer = Time.time;
    }

    void FixedUpdate() {
        if (isShaking) {
            if (Time.time - shakeTimer > .01f) {
                shakeTimer = Time.time;
                if (isHardShake) {
                    transform.position = originalPos + (Vector3.up * Random.Range(-hardShakePower, hardShakePower)) + (Vector3.right * Random.Range(-hardShakePower, hardShakePower));
                }
                else {
                    transform.position = originalPos + (Vector3.up * Random.Range(-softShakePower, softShakePower)) + (Vector3.right * Random.Range(-softShakePower, softShakePower));
                }
            }
        }
    }

    public void shake(bool hardShake) {
        if (!isShaking) {
            isShaking = true;
            isHardShake = hardShake;
            shakeTimer = Time.time;
            StartCoroutine(shakerTimer());
        }
    }

    void resetShake() {
        isShaking = false;
        transform.position = originalPos;
    }

    IEnumerator shakerTimer() {
        if (isHardShake) {
            yield return new WaitForSeconds(hardShakeTime);
        }
        else {
            yield return new WaitForSeconds(softShakeTime);
        }
        resetShake();
    }
}
