using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefab;
   public float maxTime;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text1;
    public GameObject gameOver;
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0.0f;
    private bool isRunning = true;
     private float spawnRate = 1.0f;
    public bool isGameOver;


    public int score;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    private void Update()
    {
        {
            if (isRunning)
            {
                if (elapsedTime >= maxTime)
                {
                    isGameOver = true;
                    gameOver.SetActive(true);
                    elapsedTime = maxTime;
                    isRunning = false;
                }

                elapsedTime += Time.deltaTime;
                int minutes = Mathf.FloorToInt(elapsedTime / 60);
                int seconds = Mathf.FloorToInt(elapsedTime % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }

    }
    IEnumerator SpawnTarget()
    {
        while(!isGameOver)
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
        text1.text = "Score : " + score;
    }
}
