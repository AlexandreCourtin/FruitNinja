using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakePower = 1f;
    public float shakeTime = .2f;

    public bool isShaking;

    Vector3 originalPos;

    void Start() {
        isShaking = false;
        originalPos = transform.position;
    }

    void FixedUpdate() {
        if (isShaking) {
            transform.position = originalPos + (Vector3.up * Random.Range(-shakePower, shakePower)) + (Vector3.right * Random.Range(-shakePower, shakePower));
        }
    }

    public void shake() {
        if (!isShaking) {
            isShaking = true;
            StartCoroutine(shakerTimer());
        }
    }

    void resetShake() {
        isShaking = false;
        transform.position = originalPos;
    }

    IEnumerator shakerTimer() {
        yield return new WaitForSeconds(shakeTime);
        resetShake();
    }
}
