using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDSingleton : MonoBehaviour
{
   
    
        public static HUDSingleton instance;
        public Image lifeImage;
        public Image scoreImage;
        
        public void UpdateScore(int score)
        {   
            scoreImage.fillAmount = Mathf.Clamp01(score / (float) 500);
        }

        public void UpdateLife(int life)
        {
            lifeImage.fillAmount = Mathf.Clamp01(life/100);
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
