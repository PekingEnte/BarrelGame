
/* ;-) */
using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {

	public float maxSpeed = 3;
	public float speed = 50f;
	public float jumpPower = 150f;

	public bool grounded;

	private Rigidbody2D rb2d;
	private Animator anim;

	void Start () 
	{
	
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	}
	

	void Update () 
	{
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));

		if (Input.GetAxis ("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3 (-4, 4, 1);
		}		
		if (Input.GetAxis ("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3 (4, 4, 1);
		}

		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			rb2d.AddForce (Vector2.up * jumpPower);
		}
	}
	void FixedUpdate()
	{
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;

		float h = Input.GetAxis ("Horizontal");

		if (grounded) 
		{
			rb2d.velocity = easeVelocity;
		}

		rb2d.AddForce ((Vector2.right * speed) * h);

		if (rb2d.velocity.x > maxSpeed) 
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) 
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}
}
