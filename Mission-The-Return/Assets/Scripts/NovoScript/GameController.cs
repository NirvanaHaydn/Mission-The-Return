using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int score = 0;
    public int life = 50;
    public Image lifeImage;
    public Text txtScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        
    }
    
    public void UpdateScore(int score)
    {
        this.score += score;
        if (HUDNova.instance != null)
        {
            HUDNova.instance.AddScore();
        }

        this.score = 0;

    }

    public void SetDamage(int damage)
    {
        life -= damage;
        if (HUDNova.instance != null)
        {
            HUDNova.instance.LoseLife();
        }
        life = 100;
    }
    public void PauseGame()
    {


        Time.timeScale = 0.0f;


    }
    public void Reset()
    {


        Time.timeScale = 1.0f;


    }
    private void GameOver()
    {
        Time.timeScale = 0.0f; // Pause game
        if (HUDNova.instance != null)
        {
            HUDNova.instance.ShowGameOver();
        }
        life = 100;
        score = 0;
    }

    private void ShowVictory()
    {
        Time.timeScale = 0.0f; // Pause game
        if (HUDNova.instance != null)
        {
            HUDNova.instance.ShowVictory();
        }
        life = 100;
        score = 0;
    }
}
