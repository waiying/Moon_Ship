using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTruck : MonoBehaviour {

    public int numTrucks;
    public static int numResources; 
    public GameObject parent;
    private GameObject[] truckList = new GameObject[] { };
    private int currNum;
    public GameObject truck;

    private void Start()
    {
        currNum = 0;
    }

	// Update is called once per frame
	void Update () {
        truckList = GameObject.FindGameObjectsWithTag("truck");
        currNum = truckList.Length;

        if (Input.GetMouseButtonDown(0))
        {
            if (currNum < numTrucks)
            {
                print("instantiated");
                GameObject ATruck = Instantiate(truck, transform.position, transform.rotation) as GameObject;
                ATruck.transform.parent = parent.transform;
            }
        }
	}

}
