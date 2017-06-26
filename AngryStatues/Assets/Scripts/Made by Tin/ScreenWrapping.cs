using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapping : MonoBehaviour {

	private Vector2 bottomLeft;
	private Vector2 topRight;
	// Use this for initialization
	void Start () {
		bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if(pos.x < bottomLeft.x) {
			pos.x = topRight.x;
		}
		if(pos.y < bottomLeft.y) {
			pos.y = topRight.y;
		}
		if(pos.x > topRight.x) {
			pos.x = bottomLeft.x;
		}
		if(pos.y > topRight.y) {
			pos.y = bottomLeft.y;
		}
		transform.position = pos;
	}
}
