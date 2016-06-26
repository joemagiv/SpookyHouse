using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {
	
	
	private GameObject playerObject;
	public float speed;
	private Animator animator;
	
	public float RotationSpeed;
	private Quaternion _lookRotation;
	private Vector3 _direction;
	
	private StartOption startOption;
	
	private Player player;
	private EnemyHealth enemyHealth;
	public float attackDamage;

	
	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag("Player");
		player = playerObject.GetComponent<Player>();
		animator = GetComponent<Animator>();
		enemyHealth = GetComponent<EnemyHealth>();
		startOption = FindObjectOfType<StartOption>().GetComponent<StartOption>();
		animator.SetBool("Fly Forward", true);
	
	}
	
	void OnCollisionStay(Collision collisionInfo) {
		if(collisionInfo.transform.tag == "Player"){
			
			animator.SetBool("Fly Forward", false);
			animator.SetBool("Melee Attack", true);
		}
	}
	
	public void DamagePlayer(){
		player.currentPlayerHealth -= attackDamage;
		player.dealDamageAudio();
	}
	
	
	// Update is called once per frame
	void Update () {
		// only move if the game has started
		if (startOption.gameStarted){
			//and if not stunned
			if (!enemyHealth.isStunned){
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, step);
				_direction = (playerObject.transform.position - transform.position).normalized;
				_lookRotation = Quaternion.LookRotation(_direction);
					transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			}
		}
		if (enemyHealth.isTrapped){
			SphereCollider sphereCollider = GetComponent<SphereCollider>();
			sphereCollider.enabled = false;
			animator.SetBool("Trapped", true);
			animator.SetBool("Fly Forward", false);
			animator.SetBool("Melee Attack", false);
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, enemyHealth.trap.transform.position, step);
			_direction = (enemyHealth.trap.transform.position - transform.position).normalized;
			//_lookRotation = Quaternion.LookRotation(_direction);
			//transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		}
		
	}
}
