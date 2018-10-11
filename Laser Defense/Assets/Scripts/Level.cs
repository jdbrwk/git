using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] float gameOverDelay = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame


    public void LoadGameOver()
    {
        StartCoroutine(WaitForGameOver());

    }

    IEnumerator WaitForGameOver()
    {
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene("Game Over");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Main");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);   
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
