using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoading : MonoBehaviour
{
	public List<GameObject> chunks;
	public float renderDistance;
	public Transform player;
	public new Transform camera;
	
    void Update()
    {
        Ray ray = new Ray(player.position, camera.rotation.eulerAngles);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity)){
			
		}
    }
}
