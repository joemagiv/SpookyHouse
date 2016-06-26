using UnityEngine;
using System.Collections;

public class GameOverText : MonoBehaviour {
	
	public Color textMeshColor;
	private TextMesh textMesh;
	
	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
	
	}
	
	// Update is called once per frame
	void Update () {
		textMesh.color = textMeshColor;
	}
}
