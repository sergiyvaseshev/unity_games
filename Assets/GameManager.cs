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
    private bool isRunning = true;
     private float spawnRate = 1.0f;
    public bool isGameOver;
    public int health;
    public int winScore;
    public GameObject healthView;
    public GameObject healthViewPrefab;
    public List <GameObject> healthViewPrefabs=new();

    public PanelData GameWinPanel;
    public PanelData GameOverPanel;
    public int score;
    public Button Hard, Easy, Medium;
    // Start is called before the first frame update
    void Start()
    {
        GameWinPanel.RestartButton.onClick.AddListener(RestartGame);
        GameOverPanel.RestartButton.onClick.AddListener(RestartGame);

        Hard.onClick.AddListener(RestartGame);
       Easy .onClick.AddListener(EasyGame);
      Medium  .onClick.AddListener(RestartGame);

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

    }private void MediumGame ()
    {
        winScore *=2;

    }private void HardGame ()
    {
        winScore *=3;

    }
}

