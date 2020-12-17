using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public static int orbs = 0;
    public GameObject secret;
    public static bool secretTriggered = false;
    // Update is called once per frame
    void Update()
    {
        if(orbs > 8 && !(secretTriggered))
        {
            SecretText();
        }
        if (secretTriggered && !(PauseMenu.paused))
        {
            secret.SetActive(false);
        }
    }
    void SecretText()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        secret.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.paused = true;
        secretTriggered = true;
    }
}
