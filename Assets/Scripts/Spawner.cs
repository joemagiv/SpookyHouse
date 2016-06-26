using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	//public GameObject enemyPrefab;
	
	public float timer;
	
	public float timeToSpawn;
	
	private GhostSpawnGroup ghostSpawnGroup;
	
	// Use this for initialization
	void Start () {
		ghostSpawnGroup = GetComponentInParent<GhostSpawnGroup>();
		SpawnGhost();
	}
	
	public void SpawnGhost(){
		GameObject enemyGhost = Instantiate(ghostSpawnGroup.ghostPrefab);
		enemyGhost.transform.parent = transform;
		enemyGhost.transform.position = transform.position;
		enemyGhost.transform.rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if (timeToSpawn <= timer){
			timer = 0f;
			SpawnGhost();
		}
	
	}
}
