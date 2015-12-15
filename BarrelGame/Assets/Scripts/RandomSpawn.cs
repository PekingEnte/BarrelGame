using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {


	public GameObject obj;
	public GameObject player;
	public int amount;
	public int range;
	public float dist;

	public GameObject[] obstacles; 
	private GameObject temp;

	// Use this for initialization
	void Start () {
		obstacles = new GameObject[amount];

		for (int i=0; i < amount; i++){

			obstacles[i] = Instantiate(obj, new Vector2((i*dist + Random.Range(-range/4f, range/4f)), Random.Range(-range/2f, range/2f)),Quaternion.identity) as GameObject;
			//obstacles[i].transform.position = ;

		}
	}
	
	// Update is called once per frame
	void Update () {
	


	}
}
