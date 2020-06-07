using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    #region config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    #endregion

    #region state variables
    [SerializeField] int currentScore = 0;
    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        UpdateScore();
    }
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = currentScore.ToString("D5");
    }

    // Update is called once per frame
    void Update()
    {

        Time.timeScale = gameSpeed;
    }

    public void ResetGame()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
