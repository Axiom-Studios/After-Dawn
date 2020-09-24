using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public static float sunset;
    private bool night = false;
    private Vector3 rot;
    private float dayLength = 300;
    // Start is called before the first frame update
    void Start()
    {
        sunset = Time.time + dayLength;
        rot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= sunset)
        {
            night = !night;
            sunset = Time.time + dayLength;
        }

        rot.z = ((sunset - Time.time) / dayLength) * 180;
        if (!night){
            rot.z += 180;
        }
        transform.rotation = Quaternion.Euler(rot);
    }
    void AddTime(float timeAdded)
    {
        sunset += timeAdded;
    }
}
