using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
	public int health;
	public float initialSpeed;
	public float speedScale;
	private float speed;

	private GameObject player;
	private new Rigidbody2D rigidbody2D;
	// Use this for initialization
	void Start () {
		speed = initialSpeed;
		player = GameObject.FindWithTag("Player");
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		speed += speedScale * initialSpeed;
		Vector2 direction = (player.transform.position - transform.position).normalized;
		rigidbody2D.velocity = direction * speed;
	}
}
