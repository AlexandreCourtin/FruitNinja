using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseSlice : MonoBehaviour
{
	public GameObject sliceLineObject;

	public bool isClicking;
	public int isOverFruit;
	public Vector3 posA;
	public Vector3 posB;

	void Start() {
		isClicking = false;
		isOverFruit = 0;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		if (Input.GetMouseButtonDown(0) && !isClicking && isOverFruit <= 0) {
			isClicking = true;
			posA = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		} else if (Input.GetMouseButtonUp(0) && isClicking && isOverFruit <= 0) {
			isClicking = false;
			posB = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			GameObject sliceLine = Instantiate(sliceLineObject, Vector3.zero, Quaternion.identity);
			sliceLine.GetComponent<SliceLineAnim>().setPos(posA, posB);

			RaycastHit2D hit = Physics2D.Raycast(posA, posB - posA, Vector2.Distance(posA, posB));
			if (hit.collider != null) {
				if (hit.collider.tag == "Fruit") {
					hit.collider.gameObject.GetComponent<FruitScript>().slice(posA, posB);
				}
			}
		} else if (Input.GetMouseButtonUp(0) && isClicking && isOverFruit > 0) {
			isClicking = false;
		}
	}
}
