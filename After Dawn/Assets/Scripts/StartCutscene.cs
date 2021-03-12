using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
	public List<Texture> startCutscene;
    public bool started;
    // Start is called before the first frame update
    void Start()
    {
        started = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
		{
			started = true;
			CutsceneControl.Initialize(startCutscene, 6);
		}
    }
}
