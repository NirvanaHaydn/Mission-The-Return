using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class GameControllerSingleton : MonoBehaviour
{

    public static GameControllerSingleton instance;
    public int score = 0;
    public int life = 100;

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
        if (HUDNovo.instance != null)  
        {
            HUDNovo.instance.AddScore();  
        }
        
        
   }

    public void SetDamage(int damage)
    {
        life -= damage;
        if (HUDNovo.instance != null)  
        {
            HUDNovo.instance.LoseLife();  
        }
        
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
        if (HUDNovo.instance != null)  
        {
            HUDNovo.instance.ShowGameOver();  
        }
        life = 100;
        score = 0;
    }

    private void ShowVictory()
    {
        Time.timeScale = 0.0f;
        if (HUDNovo.instance != null)  
        {
            HUDNovo.instance.ShowVictory(); 
        }
        life = 100;
        score = 0;
    }
}

