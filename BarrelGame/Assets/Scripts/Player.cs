using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	//da bekommt der player physik in seinen körper
	private Rigidbody2D rb2d;
	//der speed, der sich nach rechts bewegt
	public float speed = 20f;
	//momentaniges leben
	public int curHealth;

//<<<<<<< HEAD
	public int gravity;

//=======
	public int points = 0;
	public Text pointsText;
	public Text curHealthText;

	public bool button = false;
//>>>>>>> origin/master

	// Use this for initialization
	void Start ()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		Physics2D.gravity = new Vector2 (0, -1f);
		curHealth = 1;
		button = false;

	}
	
	// Update is called once per frame
	void Update () 
	{//es soll angezeigt werden: "Bier" dahinter die anzahl der punkte
		pointsText.text = ("Bier: " + points);
		curHealthText.text = ("Leben:" + curHealth);
		//wenn das leben unter 0 sinkt, stirbt der player
		if (curHealth <= 0) {
			
			Die ();
			
		}
		//wenn das leben größer gleich zwei ist, dann bleibt der spieler auf 2 leben
		if (curHealth >= 2) {
			curHealth =2;
		}

//		if (Input.GetKeyDown(KeyCode.Space)) 
//		{
//			button = true;
//			Debug.Log("Space");
//			
//		} 
//		else if (Input.GetKeyUp(KeyCode.Space))
//		{
//			button = false;
//		}

	}

	void FixedUpdate() 
	{
		//gravity wird mit space geändert, so dass der player bestimmt, ob er hoch oder runter geht

		if (button == true){
			rb2d.AddForce(new Vector2(0,gravity));
		}


		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			//die gravity wird um minus 1 verändert ==> die gravitationskraft wirkt nach oben statt nach unten. udn das immer *-1 das heißt b eim zweiten mal drücken sollte die gravity wieder nach unten wirken
			Physics2D.gravity = new Vector2(0, gravity/10f);
			Debug.Log("Space");
			
		} 
		else if (Input.GetKeyUp (KeyCode.Space))
			{
			Physics2D.gravity = new Vector2(0, -gravity/10f);
		}


//		if (button == true){
//			Physics2D.gravity = new Vector2(0, gravity/10f);
//		}
//
//		else if (button == false){
//			Physics2D.gravity = new Vector2(0, -gravity/10f);
//		}


		//Debug.Log(Physics2D.gravity +", "+rb2d.position);

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
	void OnTriggerEnter2D(Collider2D col)
	{
		//wenn man mit gegen den Gegenstand mit dem Tag "Bier" stößt
		if (col.CompareTag ("Bierglas")) 
		
		{//dann wird dieser Gegenstand zerstört 
			Destroy (col.gameObject);
			//und die punktzahl steigt um 1.
			points += 1;
		}
		if (col.CompareTag ("extraBarrel"))
		{
			Destroy (col.gameObject);
		}
	}

}
