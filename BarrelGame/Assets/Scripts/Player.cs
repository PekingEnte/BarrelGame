using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rb2d;

	public float speed = 20f;
	public int curHealth;


	// Use this for initialization
	void Start ()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		Physics2D.gravity = new Vector2 (0, -1f);
		curHealth = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (curHealth <= 0) {
			
			Die ();
			
		}
	}

	void FixedUpdate() 
	{
		//gravity wird mit space geändert, so dass der player bestimmt, ob er hoch oder runter geht
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Physics2D.gravity *= -1;
			
		} 

		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f; 
		//das ist der vector der dafür sorgt, dass der typ nach oben und unten geht der rest macht das smooth(?)
		rb2d.AddForce ((Vector2.right * speed));
		rb2d.velocity = easeVelocity;
	}

	public void Damage(int dmg)
	{
		curHealth -= dmg;
	}

	public void ExtraBarrel(int exBar)
	{
		curHealth += exBar;
	}

	void Die ()
	{
		
		Application.LoadLevel (1);
		
	}

}
