using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour {
	public float speed;
	public float timeout;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;
		Destroy(gameObject, timeout);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
