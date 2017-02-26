using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonGravityBody : MonoBehaviour {

    public MoonAttractor attractor;
    private Transform myTransform;
	
	// Update is called once per frame
	void Start () {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
        attractor = GameObject.Find("Moon").GetComponent<MoonAttractor>();

	}

    private void Update()
    {
        attractor.Attract(myTransform);
    }
}
