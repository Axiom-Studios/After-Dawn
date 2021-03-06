﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public static float sunset;
    public static bool night = false;
    public static float dayLength = 120f;
    public float minAmbientLight;
    public static int day = 0;
    public GameObject passText;
    public GameObject failText;
    public GameObject sun;
    public GameObject tutBarrier;
    Vector3 rot;
    public static float initialSunset;
    // Start is called before the first frame update
    void Start()
    {
        day = 0;
        dayLength = 120f;
        sunset = Time.time + dayLength;
        initialSunset = sunset;
        rot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //toggles day and night and sets a new time to do so. Sunset can technically be sunrise, too.
        if (Time.time >= sunset)
        {
            night = true;
            if (Player.passed && !(Player.gameWon))
            {
                day += 1;
                dayLength -= 20f;
                passText.SetActive(true);
            }
            else
            {
                if(!Player.gameWon)
                {
                    dayLength += 20f;
                    Player.beacons = 0;
                    failText.SetActive(true);
                }
            }
            night = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            PauseMenu.paused = true;
            sunset = Time.time + dayLength;
            initialSunset = sunset;
            if (day > 0)
            {
                tutBarrier.SetActive(true);
            }
        }
        if(!PauseMenu.paused){
            night = false;
            Player.passed = false;
        }

        float preRotZ = rot.z;

        //determines the position of the sun by rotating it around the worlds z-axis. Rotation is proportional to dayLength, allowing changable lengths of day.
        sunset = Mathf.Clamp(sunset, 0f, dayLength + Time.time);
        rot.z = (((sunset - Time.time) / dayLength) * 180) - 190;

        // make rot.z positive
        rot.z = rot.z % 360;
        if (rot.z < 0)
        {
            rot.z = 360 + rot.z;
        }

        Light sunLight = sun.GetComponent<Light>();

        transform.rotation = Quaternion.Euler(rot);

        // calculate light intensity - if statement for night time
        if (0f <= rot.z && rot.z <= 180f)
        {
            sunLight.intensity = 0f;
            RenderSettings.ambientIntensity = minAmbientLight;
        }
        else
        {
            sunLight.intensity = (90f - Mathf.Abs(rot.z - 270)) / 90;
            RenderSettings.ambientIntensity = (90f - Mathf.Abs(rot.z - 270)) / 90 * (1 - minAmbientLight) + minAmbientLight;
        }
    }
    void AddTime(float timeAdded)
    {
        //place-holder function, isn't really needed but can be used to add time to the day from within this script.
        sunset += timeAdded;
    }
}
