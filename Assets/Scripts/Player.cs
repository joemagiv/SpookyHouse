using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	
	public float currentPlayerHealth;
	public float totalPlayerHealth;
	
	public float playerScore;
	
	private Animator healthAnimator;
	private StartOption startOption;
	
	public AudioClip damageSound;
	private AudioSource audioSource;
	
	
	public bool isDead = false;
	
	public bool fullHealth = true;
	private bool seventyFiveHealth = false;
	private bool fiftyHealth = false;
	private bool twentyFiveHealth = false;
	

	
	// Use this for initialization
	void Start () {
		currentPlayerHealth = totalPlayerHealth;
		healthAnimator = FindObjectOfType<MainCamera>().GetComponent<Animator>();
		startOption = FindObjectOfType<StartOption>().GetComponent<StartOption>();
		audioSource = GetComponent<AudioSource>();
		
		
	}
	
	public void dealDamageAudio(){
		if(!isDead){
			audioSource.clip = damageSound;
			audioSource.Play ();
		}
	}
	
	void SeventyFiveHealth(){
		fullHealth = false;
		seventyFiveHealth = true;
		healthAnimator.SetBool("75percent", true);
	}
	
	void FiftyHealth(){
		healthAnimator.SetBool("75percent", false);
		seventyFiveHealth = false;
		fiftyHealth = true;
		healthAnimator.SetBool("50percent", true);
	}
	
	void TwentyFiveHealth(){
		healthAnimator.SetBool("50percent", false);
		fiftyHealth = false;
		twentyFiveHealth = true;
		healthAnimator.SetBool("25percent", true);
	}
	
	void Dead(){
		healthAnimator.SetBool("25percent", false);
		twentyFiveHealth = false;
		isDead = true;
		healthAnimator.SetBool("Dead", true);
			
	}
	
	public void Reset(){
		healthAnimator.SetBool("Dead", false);
		healthAnimator.SetBool("Reset", true);
		fullHealth = true;
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
		if (fullHealth){
			if (currentPlayerHealth/totalPlayerHealth <= 0.75f){
				SeventyFiveHealth();
			}
		}
		if (seventyFiveHealth){
			if (currentPlayerHealth/totalPlayerHealth <= 0.50f){
				FiftyHealth();
			}
		}
		if (fiftyHealth){
			if (currentPlayerHealth/totalPlayerHealth <= 0.25f){
				TwentyFiveHealth();
			}
		}
		if (twentyFiveHealth){
			if (currentPlayerHealth/totalPlayerHealth <= 0f){
				Dead();
			}
		}
		
	
	}
}
