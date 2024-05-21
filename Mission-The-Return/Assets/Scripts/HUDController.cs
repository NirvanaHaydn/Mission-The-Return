using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    
    public GameObject[] panels;

    
    void Start()
    {
        
        if (panels.Length > 0)
        {
            panels[0].SetActive(true);
        }
    }
    public void ShowPanel(int panelIndex)
    {
        
        if (panelIndex >= 0 && panelIndex < panels.Length)
        {
            // Hide all panels
            foreach (GameObject panel in panels)
            {
                panel.SetActive(false);
            }

            
            panels[panelIndex].SetActive(true);
        }
        else
        {
            Debug.LogError("Invalid panel index: " + panelIndex);
        }
    }
    public void HideActivePanel()
    {
        
        GameObject activePanel = null;
        foreach (GameObject panel in panels)
        {
            if (panel.activeSelf)
            {
                activePanel = panel;
                break;
            }
        }

      
        if (activePanel != null)
        {
            activePanel.SetActive(false);
        }
    }

    //
    public void ShowSettingsPanel()
    {
        ShowPanel(2);
    }

    
    public void ShowGameOverPanel()
    {
        ShowPanel(3); 
    }
    public void onBtnEnterStart(string name)
    {
        SceneManager.LoadScene(name);
        
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }
}

