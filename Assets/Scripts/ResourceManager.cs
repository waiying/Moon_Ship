using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    public Text canvas;

    private int ore;
  
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if(ore != InstantiateTruck.numResources)
        ore = InstantiateTruck.numResources;

        updateResources();
    }

    void updateResources()
    {
        canvas.text = "Moon Ore: " + ore;
    }
}
