using UnityEngine;
using System.Collections;

public class TrapSpawner : MonoBehaviour {
	
	public GameObject trapPrefab;
	public float trapVelocity;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	void SpawnTrap(){
		GameObject trap = Instantiate(trapPrefab, transform.position, transform.rotation) as GameObject;
		Rigidbody trapRigidBody = trap.GetComponent<Rigidbody>();
		trapRigidBody.velocity = transform.forward * trapVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1)){
			Debug.Log("Getting mouse 1");
			SpawnTrap();
		}
	}
}
