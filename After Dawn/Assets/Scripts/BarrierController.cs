using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public int order;

    // Update is called once per frame
    void Update()
    {
        // Remove for March release
        if (DayNightCycle.day == order)
        {
            Destroy(gameObject);
        }
        

    }
}
