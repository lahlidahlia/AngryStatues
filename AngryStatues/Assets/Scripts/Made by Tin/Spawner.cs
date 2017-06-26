using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	// Screen positions
	private Vector2 bottomLeft;
	private Vector2 topRight;


	public GameObject statue;
	public GameObject skeleton;
	public GameObject ghost;

	private float spawnTimer;
	public float spawnTime;
	public List<float> spawnChances;
		
		
	// Use this for initialization
	void Start () {
		bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));

		spawnTimer = spawnTime;
	}

	// Update is called once per frame
	void Update() {
		spawnTimer -= Time.deltaTime;
		if (spawnTimer < 0) {
			spawnTimer = spawnTime;

			float chanceSum = 0;
			for (int i = 0; i < spawnChances.Count; ++i) {
				// Sum up the chances.
				chanceSum += spawnChances[i];
			}
			float randomNumber = Random.Range(0, chanceSum);
			int spawnDecision = 0;
			float decisionSum = 0;  // Used to pick the decision;
			for (int i = 0; i < spawnChances.Count; ++i) {
				decisionSum += spawnChances[i];
				if (decisionSum > randomNumber) {
					spawnDecision = i;
					break;
				}
			}

			switch (spawnDecision) {
				case 0:
					Instantiate(statue, chooseSpawnPosition(), Quaternion.identity);
					break;
				case 1:
					Instantiate(skeleton, chooseSpawnPosition(), Quaternion.identity);
					break;
				case 2:
					Instantiate(ghost, chooseSpawnPosition(), Quaternion.identity);
					break;
				default:
					print("Something went wrong in Spawner");
					Instantiate(skeleton, chooseSpawnPosition(), Quaternion.identity);
					break;
			}
		}
	}

	Vector2 chooseSpawnPosition() {
		int spawnDirection = Random.Range(0, 4);
		Vector2 position = new Vector2(0, 0);  // Initialize.
		switch (spawnDirection) {
			case 0:
				position.x = Random.Range(bottomLeft.x, topRight.x);
				position.y = topRight.y;
				break;
			case 1:
				position.x = bottomLeft.x;
				position.y = Random.Range(bottomLeft.y, topRight.y);
				break;
			case 2:
				position.x = Random.Range(bottomLeft.x, topRight.x);
				position.y = bottomLeft.y;
				break;
			case 3:
				position.x = topRight.x;
				position.y = Random.Range(bottomLeft.y, topRight.y);
				break;

		}
		return position;
	}
}
