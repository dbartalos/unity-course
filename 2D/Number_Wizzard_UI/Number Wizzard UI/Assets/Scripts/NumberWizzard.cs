using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberWizzard : MonoBehaviour
{

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 768, false);
        StartGame();        
    }

    void StartGame()
    {
        NextGuess();
        max++;
    }

    public void OnPressHigher() {
        min = guess;
        NextGuess();
    }

    public void OnPressLower() {
        max = guess;
        NextGuess();
    }

    public void QuitGame() {
        Application.Quit();
    }    
    void NextGuess()
    {
        guess = (max + min) / 2;
        guessText.text = guess.ToString();
    }
}
