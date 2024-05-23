using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelSettings;

    // Start is called before the first frame update
    public void Start()
    {
        panelSettings.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }


    public void Settings()
    {
        if (panelSettings.activeSelf == false)
        {
                panelSettings.SetActive(true);

        }

        else if (panelSettings.activeSelf == true)
        {
            panelSettings.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Ви вийшли");
    }
    // Update is called once per frame
  
}
