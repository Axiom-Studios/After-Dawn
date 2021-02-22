using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeaconCount : MonoBehaviour
{
    TextMeshProUGUI beacons;
    // Start is called before the first frame update
    void Start()
    {
        beacons = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        beacons.SetText("Beacons: " + Player.beacons);
    }
}