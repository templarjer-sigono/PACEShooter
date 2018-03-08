using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMover : MonoBehaviour {

//PLAYER MOVEMENT
public float forceValue;
public float MaxSpeed;
public float decreasingSpeed;

//BULLET AND COLLISION
public Rigidbody2D rigidbody2Dp;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 force2D = Vector2.zero;

		if (Input.GetKey (KeyCode.W)) {
			//this.transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
			force2D.y += forceValue;
		
		}
		if (Input.GetKey (KeyCode.S)) {
			//this.transform.position += new Vector3 (0, -speed * Time.deltaTime, 0);
			force2D.y -= forceValue;

		}
		if (Input.GetKey (KeyCode.A)) {
			force2D.x -= forceValue;

		}
		if (Input.GetKey (KeyCode.D)) {
			force2D.x += forceValue;

		}
		if (force2D != Vector2.zero) {
			rigidbody2Dp.AddForce (force2D);
			float speed = rigidbody2Dp.velocity.magnitude;
			if (speed > MaxSpeed) {
				speed = MaxSpeed;
			}
			rigidbody2Dp.velocity = rigidbody2Dp.velocity.normalized * speed;
		} else {
			float speed = rigidbody2Dp.velocity.magnitude;
			speed -= decreasingSpeed * Time.deltaTime;
			if (speed < 0) {
				speed = 0;
			}
			rigidbody2Dp.velocity = rigidbody2Dp.velocity.normalized * speed;
		}

	}
}
