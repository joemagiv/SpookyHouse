using UnityEngine;
using System.Collections;

public class StartOption : MonoBehaviour {
	
	public bool gameStarted;
	public GameObject ghostSpawnGroup;
	
	private EnemyHealth enemyHealth;
	
	private MeshRenderer meshRender;
	private CapsuleCollider capsuleCollider;
	private ResetOption resetOption;
	private Player player;
	
	
	// Use this for initialization
	void Start () {
		enemyHealth = GetComponent<EnemyHealth>();
		meshRender = GetComponent<MeshRenderer>();
		capsuleCollider = GetComponent<CapsuleCollider>();
		resetOption = FindObjectOfType<ResetOption>().GetComponent<ResetOption>();
		player = FindObjectOfType<Player>().GetComponent<Player>();
		
	}
	
	void gameStart(){
		Instantiate(ghostSpawnGroup);
		gameStarted = true;
		
		meshRender.enabled = false;
		capsuleCollider.enabled = false;
		resetOption.resetTriggered = false;
		
	}
	
	public void gameReset(){
		enemyHealth.currentHealth = 5;
		gameStarted = false;
		GhostSpawnGroup activeGhostSpawnGroup = FindObjectOfType<GhostSpawnGroup>().GetComponent<GhostSpawnGroup>();
		EnemyHealth resetEnemyHealth = FindObjectOfType<ResetOption>().GetComponent<EnemyHealth>();
		CapsuleCollider resetCapsule = FindObjectOfType<ResetOption>().GetComponent<CapsuleCollider>();
		
		Destroy(activeGhostSpawnGroup.gameObject);
		
		Trap[] traps = FindObjectsOfType<Trap>();
		foreach (Trap trap in traps){
			Destroy(trap.gameObject);
		}
		
		
		meshRender.enabled = true;
		capsuleCollider.enabled = true;
		capsuleCollider.isTrigger =false;
		resetEnemyHealth.isDead = false;
		resetCapsule.isTrigger = false;
		resetEnemyHealth.isDead = false;
		enemyHealth.isDead = false;
		player.isDead = false;
		player.currentPlayerHealth = player.totalPlayerHealth;
		player.fullHealth = true;
		player.Reset();
		resetEnemyHealth.currentHealth = 5;
		
		
		
		

		
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameStarted){
			if (enemyHealth.currentHealth <= 0){
				gameStart();
			}
		}
	}
}
