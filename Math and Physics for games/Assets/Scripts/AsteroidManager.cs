using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AsteroidManager : MonoBehaviour
{

    public int waves;
    public int asteroidsRemaining;
    public int increaseEachWave = 4;
    public int Score = 0;
    public TextMeshProUGUI score;
    public TextMeshProUGUI wave;


    public static AsteroidManager _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    private void Update()
    {
        GameStateCheck();
        wave.text = waves.ToString();
    }
    public void GameStateCheck()
    {
        Debug.Log("Asteroids Remaining: " + asteroidsRemaining);
        if (asteroidsRemaining == 0)
        {
            waves += 1;
        }
    }

    public virtual int ScoreChange(int points)
    {
        int temp = points;
        Score = temp + Score;
        score.text = Score.ToString();

        Debug.Log("Current Score: " + Score);

        return Score;
    }

    public virtual void PlaySound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
