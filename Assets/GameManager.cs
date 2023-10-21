using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefab;
    public GameObject carsView;
    public float spawnRange = 9f;
    public int enemyCount;
    public int enemySpawnCount;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI text;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
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



    public void UpdateScore(int scoreToAdd)
    {
        score+= scoreToAdd;
        text.text = "Score : " + score;
    }
}
