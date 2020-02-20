using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
	public float time = 1f;

	void Start() {
		Destroy(gameObject, time);
	}
}
