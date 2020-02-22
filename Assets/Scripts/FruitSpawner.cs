using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
	public GameObject[] fruitsToSpawn;
	public int[] objectQueue;

	void Start() {
		objectQueue = new int[3] {-1, -1, -1};
		StartCoroutine(spawnFruit());
	}

	IEnumerator spawnFruit() {
		while(true) {
			int fruitId = objectQueue[0];

			while (fruitId == objectQueue[0] || fruitId == objectQueue[1] || fruitId == objectQueue[2]) {
				fruitId = Random.Range(0, fruitsToSpawn.Length);
			}

			Instantiate(fruitsToSpawn[fruitId], new Vector3(Random.Range(-4f, 4f), -10f, 0f), Quaternion.identity);
			objectQueue[2] = objectQueue[1];
			objectQueue[1] = objectQueue[0];
			objectQueue[0] = fruitId;
			if (fruitId >= fruitsToSpawn.Length) fruitId = 0;
			yield return new WaitForSeconds(Random.Range(.6f, 1.6f));
		}
	}
}
