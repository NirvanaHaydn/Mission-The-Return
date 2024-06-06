using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDSingleton : MonoBehaviour
{

    public static HUDSingleton instance;
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

    }

    public void LoseLife()
    {
        life = life - 1.0f;
        lifeImage.fillAmount = life;
        if(life <= 0)
        {
            ShowGameOver();
        }
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