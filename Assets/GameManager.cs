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
    public GameObject gameWin;
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0.0f;
    private bool isRunning = true;
     private float spawnRate = 1.0f;
    public bool isGameOver;
    public int health;
    public int winScore;
    public GameObject healthView;
    public GameObject healthViewPrefab;
    public List <GameObject> healthViewPrefabs=new();

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < health; i++)
        {
            var healthObject = Instantiate(healthViewPrefab, healthView.transform);
            healthViewPrefabs.Add(healthObject);
        }

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
                    GameOver(false);
                   elapsedTime = maxTime;
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
        if (scoreToAdd < 0)
        {
            health--;
            healthViewPrefabs[health].SetActive(false);

            if (health == 0)
            {
                GameOver(false);
            }
        }
        score+= scoreToAdd;

        if(score >= winScore)
        {
            GameOver(true);
        }
        text.text = "Score : " + score;
        text1.text = "Score : " + score;
    }

    private void GameOver(bool win)
    {
        isGameOver = true;
        if(win)
        {
            gameWin.SetActive(true);
        }
        else
        {
            gameOver.SetActive(true);
        }
       
        isRunning = false;
    }
}
