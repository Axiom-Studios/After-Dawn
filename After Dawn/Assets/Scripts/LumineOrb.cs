using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumineOrb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.walkSpeed += 0.5f;
            //Player.runSpeed += 0.5f;
            Destroy(gameObject);
        }
    }
}
