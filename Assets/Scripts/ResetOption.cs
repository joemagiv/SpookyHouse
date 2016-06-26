using UnityEngine;
using System.Collections;

public class ResetOption : MonoBehaviour {
	
	private StartOption startOption;
	private EnemyHealth enemyHealth;
	
	public bool resetTriggered;
	
	// Use this for initialization
	void Start () {
		startOption = FindObjectOfType<StartOption>().GetComponent<StartOption>();
		enemyHealth = GetComponent<EnemyHealth>();
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!resetTriggered){
			if (enemyHealth.currentHealth <= 0){
				resetTriggered = true;
				startOption.gameReset();
			}
			
		}
	
	}
}
