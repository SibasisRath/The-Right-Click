using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    [SerializeField] GameObject _pausedScreen;
    private bool isPaused;

    private int _lives;

    private int _score;
    [SerializeField] TextMeshProUGUI livesLeft;
    public TextMeshProUGUI proUGUI;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button _restart;

    public GameObject titleScreen;

    public int Lives { get => _lives; set => _lives = value; }
    public int Score { get => _score; set => _score = value; }

    public void UpdateLives(int a)
    {
        Lives += a;
        livesLeft.text = "Lives: " + Lives;
    }

    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        proUGUI.text = "Score: " + Score;
    }

    IEnumerator SpawnObjects(int spawnRate)
    {
        while (isGameActive)
        {
            for (int i = 0; i<spawnRate; i++)
            {
                Instantiate(targets[Random.Range(0, targets.Count)]);
            }
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        _restart.gameObject.SetActive(true);
    }

    public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void StartGame(int spawnRate)
    {
        titleScreen.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnObjects(spawnRate));
        Score = 0;
        Lives = 3;
        UpdateLives(0);
        UpdateScore(0);
        isPaused = false;
        _pausedScreen.SetActive(isPaused);
    }

    void ThePauseFunction()
    {
        if(isPaused == false)
        {
            isPaused = true;
            _pausedScreen.SetActive(isPaused);
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            _pausedScreen.SetActive(isPaused);
            Time.timeScale = 1;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ThePauseFunction();
        }
    }
}
