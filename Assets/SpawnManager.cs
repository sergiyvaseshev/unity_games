using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject carsView;
    public float spawnRange = 9f;
    public int enemyCount;
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

            var enemy = Instantiate(enemyPrefab);
            var enemyView = Instantiate(carsView);

           
        }


    }
}
