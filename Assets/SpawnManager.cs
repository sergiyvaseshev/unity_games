using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefab;
    public GameObject carsView;
    public float spawnRange = 9f;
    public int enemyCount;
    public int enemySpawnCount;
    private float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnTarget());
    }
    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index= Random.Range(0,enemyPrefab.Length);
            Instantiate(enemyPrefab[index]);

        }
    }
    [ContextMenu("Spawn")]
    void Spawn(int count)

    {

       

    }
}
