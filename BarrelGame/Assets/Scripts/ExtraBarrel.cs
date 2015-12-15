using UnityEngine;
using System.Collections;

public class ExtraBarrel : MonoBehaviour {
	
	
	
	private Player player;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		
	}
	//wenn das herz den player berührt
	void OnTriggerEnter2D(Collider2D col){
		
		if(col.CompareTag ("Player")){
			//dann kriegt er +1 leben
			player.ExtraBarrel (1);
			
		}
	}
}