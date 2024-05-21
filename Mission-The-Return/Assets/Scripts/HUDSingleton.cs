using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDSingleton : MonoBehaviour
{
   
    
        public static HUDSingleton instance;
        public Image imgScore;
        public Image imgLife;
        
        public void UpdateScore(int score)
        {
            imgScore.fillAmount =+ score;
        }

        public void UpdateLife(int life)
        {
            imgLife.fillAmount =+ life;
        }
        public void OnApplicationQuit()
        {
            Application.Quit();
        }   
        public void ShowGameOver()
        {
            SceneManager.LoadScene("GameOver");
        }
        public void ShowVictory()
        {
            SceneManager.LoadScene("Victory");
        }

}
