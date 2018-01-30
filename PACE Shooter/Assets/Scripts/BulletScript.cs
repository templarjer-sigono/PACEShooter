using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Rigidbody2D rigidbody2D;
	private SpriteRenderer spriteRenderer;
	private float speed = 50;

	public void InitAndShoot(Vector2 direction)
	{
		rigidbody2D = this.GetComponent<Rigidbody2D> ();
		spriteRenderer = this.GetComponent<SpriteRenderer> ();

		spriteRenderer.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		rigidbody2D.velocity = speed * direction;


	}
	void OnCollisionEnter2D(Collision2D coll){
		Destroy (gameObject);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
