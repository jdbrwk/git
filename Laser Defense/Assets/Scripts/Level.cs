using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");   
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
