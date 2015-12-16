using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
	
	
	private Player player;
	//"player bezieht sich aus dem playerscript"
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		
	}
	//wenn die spikes den "player" berührt
	void OnTriggerEnter2D(Collider2D col){
		
		if(col.CompareTag ("Player")){
			//dann kriegt er einen schaden
			player.Damage (1);
			Debug.Log("Treffer");
		}
	}
}