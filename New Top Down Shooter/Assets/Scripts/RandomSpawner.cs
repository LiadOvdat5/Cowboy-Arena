using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawners;
    public GameObject enemyPrefab;
   
    public int maxEnemies = 4;


    //Time
    public int spawnTime = 1;
    public float spawnRate = 2f;


    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnRate);
        
    }

    



    public void SpawnEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            int ranSpawner = Random.Range(0, spawners.Length);
            Instantiate(enemyPrefab, spawners[ranSpawner].position, transform.rotation);



           // Debug.Log("enemy number" + GameObject.FindGameObjectsWithTag("Enemy").Length);
        }

    }
}
