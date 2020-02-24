using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseSlice : MonoBehaviour
{
	public GameObject sliceLineObject;

	public bool isSlicing;
	public int isOverFruit;
	public float clickTimer;
	public Vector3 posA;
	public Vector3 posB;

	float FirstClickTimer;

	void Start() {
		isSlicing = false;
		isOverFruit = 0;
		clickTimer = 0f;
		FirstClickTimer = 0f;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		if (Input.GetMouseButtonDown(0) && !isSlicing) {
			isSlicing = true;
			posA = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			FirstClickTimer = Time.time;
		} else if (isSlicing && Time.time - FirstClickTimer >= .1f) {
			isSlicing = false;
			posB = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			GameObject sliceLine = Instantiate(sliceLineObject, Vector3.zero, Quaternion.identity);
			sliceLine.GetComponent<SliceLineAnim>().setPos(posA, posB);
			castSliceRaycast();
		}
	}

	void castSliceRaycast() {
		RaycastHit2D hit = Physics2D.Raycast(posA, posB - posA, Vector2.Distance(posA, posB));
		if (hit.collider != null) {
			if (hit.collider.tag == "Fruit") {
				hit.collider.gameObject.GetComponent<FruitScript>().slice(posA, posB);
				castSliceRaycast();
			}
		}
	}
}
