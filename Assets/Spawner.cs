using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int gameObjectSpawnNum;
    public float speed;
    public float bound;
    public float spawnRangeX;
    public float spawnPosZ;
    public GameObject[] gameObjectsSpawn;
    public float startDelay ;
    public float spawnInterval ;
    public Transform spawntransform;
    // Start is called before the first frame update
    private control player;
    void Start()
    {

        player = GameObject.Find("Player").GetComponent<control>();
        InvokeRepeating("SpawnAnimals", startDelay, spawnInterval);
    }
    


    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.F))
        {
             SpawnAnimals();
        }
    }

   private void SpawnAnimals()
    {
        /*float posX = Random.Range(-spawnRangeX, spawnRangeX);

        Vector3 spawnPos = new Vector3(posX, 0, spawnPosZ);
        Vector3 rotation = new Vector3(0, 180, 0);
        Debug.Log("тест gameObjectsSpawn.Length = " + gameObjectsSpawn.Length);

        gameObjectSpawnNum = Random.Range(0, gameObjectsSpawn.Length);
        Debug.Log("тест gameObjectSpawnNum = " + gameObjectSpawnNum);*/
        if (player.gameOver == false)
        {

            Instantiate(gameObjectsSpawn[gameObjectSpawnNum], spawntransform.position, transform.rotation);

        }
    }
}
