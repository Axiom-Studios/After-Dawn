using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotate : MonoBehaviour
{
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(70f, 0, playerTransform.eulerAngles.y);
    }
}
