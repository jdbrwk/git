using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberWizard : MonoBehaviour {

    [SerializeField] int maxNumber;
    [SerializeField] int minNumber;
    [SerializeField] TextMeshProUGUI guessText;


    int guess;


	// Use this for initialization
	void Start () {
        StartGame();
	}
	
    void StartGame() 
    {
        MyGuess();

    }

    public void OnPressLower()
    {
        maxNumber = guess - 1;
        MyGuess();
    }

    public void OnPressHigher()
    {
        minNumber = guess + 1;
        MyGuess();
    }

    void MyGuess() 
    {
        guess = Random.Range(minNumber, maxNumber);
        guessText.text = guess.ToString();


      }
}
