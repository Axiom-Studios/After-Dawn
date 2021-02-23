using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeaconCount : MonoBehaviour
{
    TextMeshProUGUI beacons;
    private float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        beacons = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = Mathf.Round(DayNightCycle.sunset) - Mathf.Round(Time.time);
        beacons.SetText("Time Remaining: " + timeLeft + "\nBeacons: " + Player.beacons);
    }
}