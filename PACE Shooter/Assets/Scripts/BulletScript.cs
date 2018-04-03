using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Rigidbody rigidbodybullet;
	private SpriteRenderer spriteRenderer;
	public float speed;

	public void InitAndShoot(Vector2 direction)
	{
		rigidbodybullet = this.GetComponent<Rigidbody> ();
		spriteRenderer = this.GetComponent<SpriteRenderer> ();

		spriteRenderer.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		rigidbodybullet.velocity = speed * direction;


	}
	void OnCollisionEnter(Collision coll){
		Destroy(gameObject);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
