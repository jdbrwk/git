using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    int score = 0;

	// Use this for initialization
	void Awake () {
        SetUpSingleton();
	}

    private void SetUpSingleton()
    {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;
        {
            if (numberGameSession > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
	
    public int GetScore()
    {
        return score;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;  
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
