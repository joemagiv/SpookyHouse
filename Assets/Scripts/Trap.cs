using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider collisionInfo) {
		//Debug.Log("Trigger detected: " + collisionInfo);
	}
	
	
	void OnTriggerStay(Collider collisionInfo) {
		//Debug.Log("TriggerStay: " + collisionInfo);
		if(collisionInfo.transform.tag == "Ghost"){
			Debug.Log("Ghost Detected");
			EnemyHealth enemyHealth = collisionInfo.GetComponent<EnemyHealth>();
			if(enemyHealth.isStunned){
				enemyHealth.isTrapped = true;
				enemyHealth.trap = this;
			}
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
