using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Button paused;

    private Player_life lifescript;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        lifescript = GameObject.Find("blob").GetComponent<Player_life>();
        lifescript.LifeEvent += onLifeEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void onLifeEvent(int remaining)
    {
        if (remaining == 0) Menu();
    }
    
   public void Resume()
    {
        pauseMenuUI.SetActive((false));
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive((true));
        GameIsPaused = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
}
  