using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSphere : MonoBehaviour
{
    private float timeAdded;
    // Start is called before the first frame update
    void Start()
    {
        timeAdded = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            DayNightCycle.sunset += timeAdded;
            Destroy(gameObject);
        }    
    }
}
