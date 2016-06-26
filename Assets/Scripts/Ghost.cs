using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
	
	public float pointsValue = 60;

	// Use this for initialization
	void Start () {
		
		
	
	}
	
	public void trapComplete(){
		Player player = FindObjectOfType<Player>().GetComponent<Player>();
		player.playerScore += pointsValue;
		Destroy(this.gameObject);
		
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
