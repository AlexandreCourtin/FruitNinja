using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseSlice : MonoBehaviour
{
	public Material lineRenderMat;

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
			createSliceLine();

			RaycastHit2D hit = Physics2D.Raycast(posA, posB - posA);
			if (hit.collider != null) {
				if (hit.collider.tag == "Fruit") {
					hit.collider.gameObject.GetComponent<FruitScript>().slice(posA, posB);
				}
			}
		} else if (Input.GetMouseButtonUp(0) && isClicking && isOverFruit > 0) {
			isClicking = false;
		}
	}

	void createSliceLine() {
		GameObject sliceLine = new GameObject();
		sliceLine.name = "SliceLine";
		sliceLine.transform.position = Vector3.zero;
		sliceLine.AddComponent<LineRenderer>();
		LineRenderer lr = sliceLine.GetComponent<LineRenderer>();
		lr.material = lineRenderMat;
		lr.SetPosition(0, new Vector2(posA.x, posA.y));
		lr.SetPosition(1, new Vector2(posB.x, posB.y));
		lr.startWidth = .1f;
		lr.endWidth = .1f;
		Destroy(sliceLine, .2f);
	}
}
