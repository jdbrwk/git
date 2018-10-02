using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {


    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float minPaddlePosx = 1f;
    [SerializeField] float maxPaddlePosx = 15f;


    Ball ball;
    GameSession gameSession;


    private void Awake()
    {
        ball = FindObjectOfType<Ball>();  
        gameSession = FindObjectOfType<GameSession>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minPaddlePosx, maxPaddlePosx);
        transform.position = paddlePos;
		
	}

    private float GetXPos()
    {
        if (gameSession.IsAutoplayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnit;
        }
    }
}
