using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<Texture> startCutscene;
    public bool started;

    void Start()
    {
        started = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (!(CutsceneControl.active) && started)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    
    public void PlayGame(){
        CutsceneControl.Initialize(startCutscene, 6);
        started = true;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
