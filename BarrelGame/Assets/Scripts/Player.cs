﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	//da bekommt der player physik in seinen körper
	private Rigidbody2D rb2d;
	//der speed, der sich nach rechts bewegt
	public float speed = 20f;
	//momentaniges leben
	public int curHealth;

	public int gravity;


	// Use this for initialization
	void Start ()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		Physics2D.gravity = new Vector2 (0, -1f);
		curHealth = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{//wenn das leben unter 0 sinkt, stirbt der player

		if (curHealth <= 0) {
			
			Die ();
			
		}
		//wenn das leben größer gleich zwei ist, dann bleibt der spieler auf 2 leben
		if (curHealth >= 2) {
			curHealth =2;
		}
	}

	void FixedUpdate() 
	{
		//gravity wird mit space geändert, so dass der player bestimmt, ob er hoch oder runter geht
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			//die gravity wird um minus 1 verändert ==> die gravitationskraft wirkt nach oben statt nach unten. udn das immer *-1 das heißt b eim zweiten mal drücken sollte die gravity wieder nach unten wirken
			Physics2D.gravity = new Vector2(0, gravity/10f);
			
		} 
		else if (Input.GetKeyUp (KeyCode.Space))
			{
			Physics2D.gravity = new Vector2(0, -gravity/10f);
		}
		Debug.Log(Physics2D.gravity +", "+rb2d.position);

		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f; 
		//das ist der vector der dafür sorgt, dass der typ automatisch nach rechts geht
		rb2d.AddForce ((Vector2.right * speed));
		rb2d.velocity = easeVelocity;
	}

	public void Damage(int dmg)
	{
		//man kriegt den dmg, der im dmg script gecoded ist
		curHealth -= dmg;
	}

	public void ExtraBarrel(int exBar)
	{
		//man kriegt das leben, was im extrabarrel script gecoded ist
		curHealth += exBar;
	}

	void Die ()
	{
		//das nächste level wird geladen, in dem ich hioghscore und so hingeschrieben hatte "Todesszene" heißt es
		Application.LoadLevel (1);
		
	}

}
