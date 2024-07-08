using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDNova : MonoBehaviour
{
    public static HUDNova instance;
    public int score = 0;
    public int life = 15;
    public Text txtLife;
    public Text txtScore;
    
    void Start()
    {
        instance = this;
    }
    public void AddScore()
    {
        score = score + 5;
        txtScore.text = " " + score;
        
        if (score >= 70)
        {
             
            ShowFaseDois();           
        } 
    }
    public void AddMore()
    {
        score = score + 4;
        txtScore.text = " " + score;

        if (score >= 40)
        {
           SceneManager.UnloadSceneAsync("SegundaFase");
           ShowVictory();
        }
    }

    public void AddLife()
    {
        life = life + 4;
        txtLife.text = " " + life;
        if(life >= 100)
        {
            life--;
        }
    }

    public void LoseLife()
    {
        life = life - 3;
        txtLife.text = " " + life;
        if (life <= 0)
        {
            HUDNova.instance.ShowGameOver();
        }
    }

    
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }
    public void ShowGameOver()
    {
        SceneManager.LoadScene("Derrota");
    }
    public void ShowVictory()
    {
        SceneManager.LoadScene("Vitoria");
    }
    public void ShowFaseDois()
    {
        SceneManager.LoadScene("SegundaFase");
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }
    public void ShowMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
