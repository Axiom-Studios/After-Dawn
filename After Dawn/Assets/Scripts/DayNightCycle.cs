using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public static float sunset;
    public static bool night = false;
    private Vector3 rot;
    private float dayLength = 300;
    public static int day = 0;
    public GameObject dayText;
    // Start is called before the first frame update
    void Start()
    {
        sunset = Time.time + dayLength;
        rot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //toggles day and night and sets a new time to do so. Sunset can technically be sunrise, too.
        if (Time.time >= sunset)
        {
            night = true;
            day += 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            dayText.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.paused = true;
            sunset = Time.time + dayLength;
        }
        if(!PauseMenu.paused){
            dayText.SetActive(false);
            night = false;
        }
        //determines the position of the sun by rotating it around the worlds z-axis. Rotation is proportional to dayLength, allowing changable lengths of day.
        rot.z = (((sunset - Time.time) / dayLength) * 180) - 190;
        transform.rotation = Quaternion.Euler(rot);
    }
    void AddTime(float timeAdded)
    {
        //place-holder function, isn't really needed but can be used to add time to the day from within this script.
        sunset += timeAdded;
    }
}
