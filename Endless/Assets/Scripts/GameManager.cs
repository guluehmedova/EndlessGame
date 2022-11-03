using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager instance;

    [SerializeField] Text scoreText;

    [SerializeField] PlayerMovement playerMovement;

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        instance = this;
    }
}
