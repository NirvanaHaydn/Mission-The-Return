using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDNova : MonoBehaviour
{
    public static HUDNova instance;
    public Image lifeImage;
    public Image scoreImage;
    public float score = 0.0f;
    public float life = 100.0f;

    void Start()
    {
        instance = this;
    }

    public void AddScore()
    {
        score = score + 0.05f;
        scoreImage.fillAmount = score;
        if (score >= 1.0f)
        {
            ShowVictory();
        }
        score = 0.0f;
    }

    public void LoseLife()
    {
        life = life - 1.0f;
        lifeImage.fillAmount = life;
        if (life <= 0)
        {
            ShowGameOver();
        }
        score = 100.0f;
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void ShowGameOver()
    {
        SceneManager.LoadScene("Derrota");
    }
    public void ShowVictory()
    {
        SceneManager.LoadScene("Vitoria");
    }

}
