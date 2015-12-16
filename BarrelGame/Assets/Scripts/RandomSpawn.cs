using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {


	public GameObject obj;          // für welches Objekt wird das Script verwendet
	public GameObject player;		// der Player
	public int amount;				// Anzahl der Instanzen
	public int range;				// Verteilung in Y-Richtung
	public float dist;				// Verteilung in X-Richtung
	public string tagName;

	public GameObject[] obstacles; 
	private GameObject temp;

	// Use this for initialization
	void Start () {
		obstacles = new GameObject[amount];

		for (int i=0; i < amount; i++){            // Erstmaliges Erstellen der Instanzen

			obstacles[i] = Instantiate(obj, new Vector2((i*dist + Random.Range(-range/4f, range/4f)), Random.Range(-range/2f, range/2f)),Quaternion.identity) as GameObject;
			obstacles[i].tag = tagName;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		for (int i=0; i < amount; i++){				// Zurücksetzen der Insatnzen

			if (player.transform.position.x - obstacles[i].transform.position.x > 10f){

				obstacles[i].transform.position = new Vector2((amount*dist + player.transform.position.x + Random.Range(-range/4f, range/4f)), Random.Range(-range/2f, range/2f));
				Debug.Log("respawn");
			}


		}
	}

}
