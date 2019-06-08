using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSpawn : MonoBehaviour
{
	public GameObject[] hammerPrefabs;
	public GameObject thorhammerPrefabs;
	public GameObject doublehammerPrefabs;
	public GameObject putRinghammerPrefabs;
	public GameObject healthPrefabs;
	public GameObject coinPrefabs;
	public Transform[] spawnPoints;
	public float spawnTime = 3;
	
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
		        
    }
	
	void Spawn(){
		if(!GameManager.gameOver && PlayerUIManager.isStarted){
			GameObject selectedHammer = hammerPrefabs[Random.Range(0, hammerPrefabs.Length)];
			int spawnPointIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnPointIndex];
			GameObject e = (GameObject)Instantiate(selectedHammer, spawnPoint.position, spawnPoint.rotation);
			
			if(GameManager.save > 60){
				int spawnPointIndex1 = Random.Range(0, spawnPoints.Length);
				if(spawnPointIndex1%2 == 0){
					Transform spawnPoint1 = spawnPoints[spawnPointIndex1];
					GameObject e2 = (GameObject)Instantiate(thorhammerPrefabs, spawnPoint1.position, spawnPoint1.rotation);
				}				
			}
			if(GameManager.save > 120){
				int spawnPointIndex1 = Random.Range(0, spawnPoints.Length);
				if(spawnPointIndex1%2 != 0){
					Transform spawnPoint1 = spawnPoints[spawnPointIndex1];
					GameObject e2 = (GameObject)Instantiate(doublehammerPrefabs, spawnPoint1.position, spawnPoint1.rotation);
				}				
			}
			
			if(GameManager.save > 190){
				int spawnPointIndex1 = Random.Range(0, spawnPoints.Length);
				if(spawnPointIndex1%3 == 0){
					Transform spawnPoint1 = spawnPoints[spawnPointIndex1];
					GameObject e2 = (GameObject)Instantiate(putRinghammerPrefabs, spawnPoint1.position, spawnPoint1.rotation);
				}				
			}
			
			if((GameManager.save % 25 == 0) && (GameManager.health <= 5)){
				int spawnPointIndex1 = Random.Range(0, spawnPoints.Length);
				Transform spawnPoint1 = spawnPoints[spawnPointIndex1];
				GameObject e2 = (GameObject)Instantiate(healthPrefabs, spawnPoint1.position, spawnPoint1.rotation);
			}
			if((GameManager.save % 15 == 0) ){
				int spawnPointIndex1 = Random.Range(0, spawnPoints.Length);
				Transform spawnPoint1 = spawnPoints[spawnPointIndex1];
				GameObject e2 = (GameObject)Instantiate(coinPrefabs, spawnPoint1.position, spawnPoint1.rotation);
			}
			
		}		
	}
}
