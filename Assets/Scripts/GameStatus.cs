﻿using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    //Config
    [Header("Customization")]
    [Range(0.1f,10f)][SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;
    
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText = null;
   
    [Header("Cheat mode for testing")]
    [SerializeField] private bool isAutoPlayEnabled;
    
    
    //State
    [SerializeField] private int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
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
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        Time.timeScale = gameSpeed;
        
    }
    
    
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
  
}

