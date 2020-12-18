using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(1f,5f)] [SerializeField] float gameSpeed=1f;

    [SerializeField] int pointsScoredPerBlockDestroyed = 80;

    [SerializeField] int CurrentScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] bool isAutoPlayOn;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = CurrentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        CurrentScore = CurrentScore + pointsScoredPerBlockDestroyed;
        scoreText.text = CurrentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayOn()
    {
        return isAutoPlayOn;
    }
}
