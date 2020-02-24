using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
	public int score = 0;

	void Start() {
		updateUI();
	}

	public void updateUI() {
		GetComponent<TextMesh>().text = "Score: " + score;
	}
}
