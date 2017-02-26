using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetController : MonoBehaviour {

    public Quaternion originalRotationValue;
    public GameObject target;

	// Use this for initialization
	void Start () {
        //originalRotationValue = gameObject.transform;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 20 * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -20 * Time.deltaTime);
        }

       // if (Input.GetKey(KeyCode.W))
       // {
       //     transform.Rotate(20 * Time.deltaTime, 0, 0);
       // }


       // if (Input.GetKey(KeyCode.S))
       // {
       //     transform.Rotate(-20 * Time.deltaTime, 0, 0);
       // }

        if (Input.GetKey(KeyCode.Space))
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        if (transform.rotation == Quaternion.identity)
        {
            SceneManager.LoadScene("Moon_Interior", LoadSceneMode.Single);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
