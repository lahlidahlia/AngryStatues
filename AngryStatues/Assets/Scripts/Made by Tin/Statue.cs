using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour {
	public int health;
	private float shootTimer;

	public float speed;
	public float shootTime;  // How long it takes to shoot a shot.
	public float shootTimeRandom;  // Add too shootTime random between 0 and shootTimeRandom.
	public float chargeTime;  // How long statue waits before shooting.

	private new Rigidbody2D rigidbody2D;

	public GameObject lazer;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		shootTimer = shootTime;
		rigidbody2D = GetComponent<Rigidbody2D>();
		rigidbody2D.velocity = getRandomDirection() * speed;
		shootTime += chargeTime;
	}
	
	// Update is called once per frame
	void Update () {
		shootTimer -= Time.deltaTime;
		if(shootTimer < 0){
			shootTimer = shootTime + Random.Range(0, shootTimeRandom);
			rigidbody2D.velocity = Vector2.zero;
			Invoke("shootLazer", chargeTime);
		}
	}

	float rotationToPosition(Vector2 position) {
		/* Get the degree rotation from a this object's position to given position.
         * 0deg starts North.
         * */
		return Mathf.Atan2(position.y - transform.position.y, position.x - transform.position.x) * Mathf.Rad2Deg + 270;
	}

	void shootLazer() {
			rigidbody2D.velocity = getRandomDirection()*speed;
			Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, rotationToPosition(player.transform.position)));
			Instantiate(lazer, transform.position, rotation);
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
