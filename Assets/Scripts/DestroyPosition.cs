using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPosition : MonoBehaviour
{
	void FixedUpdate() {
		if (transform.position.y <= -20f) {
			Destroy(gameObject);
		}
	}
}
