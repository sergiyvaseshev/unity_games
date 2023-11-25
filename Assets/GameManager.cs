using Assets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefab;
   public float maxTime;
    public TextMeshProUGUI text;
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0.0f;
    private bool isRunning = false;
     private float spawnRate = 1.0f;
    public bool isGameOver= true;
    public int health;
    public int winScore;
    public GameObject healthView;
    public GameObject healthViewPrefab;
    public List <GameObject> healthViewPrefabs=new();

    public GameObject Startgame;
    public PanelData GameWinPanel;
    public PanelData GameOverPanel;
    public int score;
    public Button Hard, Easy, Medium;
    // Start is called before the first frame update
    void Start()
    {
        GameWinPanel.RestartButton.onClick.AddListener(RestartGame);
        GameOverPanel.RestartButton.onClick.AddListener(RestartGame);

      
       Easy .onClick.AddListener(EasyGame);
      Medium  .onClick.AddListener(MediumGame);
      Hard.onClick.AddListener( HardGame);


       
        UpdateScore(0);
        
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
        GameOverPanel.text1.text = "Score : " + score;
        GameWinPanel.text1.text = "Score : " + score;

    }

    private void GameOver(bool win)
    {
        isGameOver = true;
        if(win)
        {
            GameWinPanel.Panel.SetActive(true);
        }
        else
        {
            GameOverPanel.Panel.SetActive(true);
        }
       
        isRunning = false;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }private void EasyGame ()
    {
        winScore *= 1;
        health = 5;

        spawnRate = 1f;

        InitGame();

    }
    private void MediumGame ()
    {

        winScore *=2;
        health = 3;
        spawnRate = 0.6f;

        InitGame();


    }
    private void HardGame ()
    {
        winScore *=3;
        health = 2;
        spawnRate = 0.3f;


        InitGame();
    }

    private void InitGame()
    {

        isGameOver = false;
        isRunning = true;

        for (int i = 0; i < health; i++)
        {
            var healthObject = Instantiate(healthViewPrefab, healthView.transform);
            healthViewPrefabs.Add(healthObject);
        }


        Startgame.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
    }
}

