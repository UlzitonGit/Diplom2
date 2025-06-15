using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private Sounds sounds;
    public GameObject pauseMenu;
    [SerializeField] protected PlayerCam playerCam;
    public bool isPaused;

    void Start()
    {
        sounds = FindObjectOfType<Sounds>();
        pauseMenu.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                sounds.StopSounds(true);
                ResumeGame();
            }
            else
            {
                sounds.StopSounds(false);
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        playerCam.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        playerCam.enabled = true;
    }

    public void GotoMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }

}

