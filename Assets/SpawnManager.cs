using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public GameObject carsView;
    public float spawnRange = 9f;
    public int enemyCount ;
    public int enemySpawnCount;
    // Start is called before the first frame update
    void Start()
    {
        Spawn(enemySpawnCount);
    }
    [ContextMenu("Spawn")]
    void Spawn(int count)

    {

        for (int i = 0; i < count; i++)
        {

          var enemy=  Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
          var enemyView=  Instantiate(carsView);

            enemy.SetCars(enemyView);
         
        }

     
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            enemySpawnCount++;
            Spawn(enemySpawnCount);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

}



    