using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoading : MonoBehaviour
{
	public List<GameObject> chunks;
	public float renderDistance;
	public Transform player;
    void Update()
    {
        foreach (GameObject chunk in chunks){
			float chunkPos = chunk.transform.position.x - chunk.transform.position.y - chunk.transform.position.z;
			float playerPos = player.position.x - player.position.y - player.position.z;
			if (Mathf.Sqrt(chunkPos + playerPos) > renderDistance){
				chunk.SetActive(false);
			}
		}
    }
}
