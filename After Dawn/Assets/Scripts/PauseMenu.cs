using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public static float worldTime = 0f;

    public GameObject pauseMenuUI;
    public GameObject endText;
    public GameObject passText;
    public GameObject failText;
    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        worldTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Player.gameWon && !paused)
        {
            Player.gameWon = false;
            SceneManager.LoadScene("Menu");
        }
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
		endText.SetActive(false);
        passText.SetActive(false);
        failText.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        paused = false;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
