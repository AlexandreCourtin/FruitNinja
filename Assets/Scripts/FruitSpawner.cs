using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
	public GameObject[] fruitsToSpawn;

	int fruitId = 0;

	void Start() {
		StartCoroutine(spawnFruit());
	}

	IEnumerator spawnFruit() {
		while(true) {
			Instantiate(fruitsToSpawn[fruitId], new Vector3(Random.Range(-4f, 4f), -10f, 0f), Quaternion.identity);
			fruitId += 1;
			if (fruitId >= fruitsToSpawn.Length) fruitId = 0;
			yield return new WaitForSeconds(2f);
		}
	}
}
