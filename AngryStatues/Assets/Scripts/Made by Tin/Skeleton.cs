using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {
	public int health;

	private float turnTimer;
	public float turnTime;  // How long it takes to turn to a new direction.
	public float turnTimeRandom;

	public float speed;
	private new Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		rigidbody2D.velocity = getRandomDirection() * speed;
	}
	
	// Update is called once per frame
	void Update () {
		turnTimer -= Time.deltaTime;

		if (turnTimer < 0) {
			turnTimer = Random.Range(turnTime, turnTime + turnTimeRandom);
			rigidbody2D.velocity = getRandomDirection() * speed;
		}		
	}


	Vector2 getRandomDirection() {
		int direction = Random.Range(0, 4);
		switch (direction) {
			case 0:  // North
				return new Vector2(0, 1);
			case 1:  // West
				return new Vector2(-1, 0);
			case 2:  // South
				return new Vector2(0, -1);
			case 3:  // East
				return new Vector2(1, 0);
			default:
				return new Vector2(0, 0);
		}
	}
}
