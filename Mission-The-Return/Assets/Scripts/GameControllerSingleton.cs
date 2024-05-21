using UnityEngine;
using static HUDSingleton;

public class GameControllerSingleton : MonoBehaviour
{
    public static GameControllerSingleton instance;
    private int score = 0;
    private int life = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int score)
    {
        this.score += score;
        if (HUDSingleton.instance != null)  
        {
            HUDSingleton.instance.UpdateScore(this.score);  
        }
        if (this.score == 500) ShowVictory();
        
    }

    public void SetDamage(int damage)
    {
        life -= damage;
        if (HUDSingleton.instance != null)  
        {
            HUDSingleton.instance.UpdateLife(life);  
        }
        if (life <= 0) GameOver();
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f; // Pause game
        if (HUDSingleton.instance != null)  
        {
            HUDSingleton.instance.ShowGameOver();  
        }
        life = 100;
        score = 0;
    }

    private void ShowVictory()
    {
        Time.timeScale = 0.0f;
        if (HUDSingleton.instance != null)  
        {
            HUDSingleton.instance.ShowVictory(); 
        }
        life = 100;
        score = 0;
    }
}

