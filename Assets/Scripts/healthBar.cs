using UnityEngine;
using System.Collections;

public class healthBar : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	
	}
	
	public void ShrinkHealth(){
		transform.localScale -= new Vector3(0.011F, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
