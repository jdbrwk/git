using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // config
    [Range(0.01f, 10)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoplayEnabled;

    // state variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
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
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void AddToScore()
    {
        currentScore += pointPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void RestartScore()
    {
        Destroy(gameObject); 
    }

    public bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
    }

}
