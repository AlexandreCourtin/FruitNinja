﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
	public GameObject slicePartOne;
	public GameObject slicePartTwo;
	public GameObject pointText;

	MouseSlice mouseSlice;
	Rigidbody2D rigidbody;

	void Start() {
		mouseSlice = GameObject.Find("Camera").GetComponent<MouseSlice>();
		rigidbody = GetComponent<Rigidbody2D>();

		rigidbody.AddForce((Vector3.up * Random.Range(500f, 575f)) + (Vector3.right * Random.Range(-125f, 125f)));
		rigidbody.AddTorque(Random.Range(-30f, 30f));
	}

	void OnMouseEnter() {
		mouseSlice.isOverFruit += 1;
	}

	void OnMouseExit() {
		mouseSlice.isOverFruit -= 1;
	}

	public void slice(Vector3 posA, Vector3 posB) {
		Instantiate(pointText, transform.position, Quaternion.identity);
		GameObject partOne = Instantiate(slicePartOne, transform.position, transform.rotation);
		GameObject partTwo = Instantiate(slicePartTwo, transform.position, transform.rotation);
		Transform partOneTransform = partOne.transform.Find("TransparencyMask");
		Transform partTwoTransform = partTwo.transform.Find("TransparencyMask");
		Vector3 dir = posB - posA;

		float angleA = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90f;
		float angleB = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90f;

		partOneTransform.rotation = Quaternion.AngleAxis(angleA, Vector3.forward);
		partTwoTransform.rotation = Quaternion.AngleAxis(angleB, Vector3.forward);

		partOne.GetComponent<Rigidbody2D>().AddForce(-partOneTransform.right * 200f);
		partTwo.GetComponent<Rigidbody2D>().AddForce(-partTwoTransform.right * 200f);

		ScoreScript scoreScript = GameObject.Find("ScoreText").GetComponent<ScoreScript>();
		scoreScript.score += 1;
		scoreScript.updateUI();
		Destroy(gameObject);
	}
}