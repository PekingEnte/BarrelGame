using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	public int points;
	public Text pointsText;
	public Transform coin1;
	public Transform coin;

	public Text pressKey;
	private float gravitySpeed = 1.2f;
	public Text youDied;
	public float speed = 50f;
	public float curSpeed;
	private Rigidbody2D rb2d;
	public int curHealth;
	public bool canPressW = true;
	public bool canPressS = true;
	private bool bGameOver = false;


	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();

		curHealth = 1;
		curSpeed = speed;
		canPressS = false;
		Physics2D.gravity = new Vector2 (0, -1f);


	}
	

	void Update () {

		pointsText.text = ("Points: " + points);

		if (bGameOver){
			pointsText.text = (" ");
			if (Input.GetKeyDown (KeyCode.Space)) { 
				bGameOver = false;
				Physics2D.gravity = new Vector2 (0, -1f);
				Application.LoadLevel(0);
			}
			
			
		}
		if (curHealth <= 0) {
			
			Die ();
			
		}
	}

	void FixedUpdate() {
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y *= 0.75f;
		easeVelocity.z = 0.0f;
		easeVelocity.x = rb2d.velocity.x;
		
		float h = Input.GetAxis ("Vertical");


		if (Input.GetKeyDown (KeyCode.W)&& canPressW) 
		{
			canPressW = false;
			canPressS = true;
			Physics2D.gravity *= gravitySpeed;
			Physics2D.gravity *= -1;
			curSpeed *= 50;

		}
		if (Input.GetKeyDown (KeyCode.S)&& canPressS) 
		{
			canPressW = true;
			canPressS = false;
			Physics2D.gravity *= gravitySpeed;
			Physics2D.gravity *= -1;
			curSpeed *= 50;
		
		}
		if (Input.GetKeyDown (KeyCode.W) && canPressW) 
		{
			rb2d.AddForce ((Vector2.up * curSpeed) * h);
			rb2d.velocity = easeVelocity;
		}

		if (Input.GetKeyDown (KeyCode.S) && canPressS) {

			rb2d.AddForce ((Vector2.up * curSpeed) * h);
			rb2d.velocity = easeVelocity;
		}
	}


	void Die ()
	{
			
			youDied.text = ("You reached: " + points + " points!");
			pressKey.text = "Press space to restart!";
			bGameOver = true;

	}

	public void Damage(int dmg)
	{
		curHealth -= dmg;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//create vector coin
		Vector3 vec = new Vector3 (0f, 2.4f, 0f);
		//create vectore coin1
		Vector3 vec1 = new Vector3 (0f, -2.4f, 0f);

		if (col.CompareTag ("Coin")) {

			Destroy(col.gameObject);
			Instantiate(coin1, vec1, Quaternion.identity);
			if(!bGameOver){
			points += 1;
			}
		}
		if (col.CompareTag ("Coin1")) {

			Destroy(col.gameObject);
			Instantiate(coin, vec, Quaternion.identity);
			if(!bGameOver){
				points += 1;
			}
			
		}

	}


}




