using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideMoonController : MonoBehaviour {

    public float speed = 5f;
    public GameObject target;
  //  public GameObject Cube;
   // public Transform Moon_As_Parent;
   // public Rigidbody rb;

   // int crossMap;
   // float distance;

    //private Vector3 input;

	// Use this for initialization
	void Start () {
       // crossMap = LayerMask.GetMask("Cross");
       // rb = target.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
      //  input = new Vector3(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"), 0);
      //  rb.AddForce(input * speed);

        if (Input.GetKey(KeyCode.Space))
        {
            //transform.rotation = Quaternion.identity;
            SceneManager.LoadScene("Moon_Exterior", LoadSceneMode.Single);
        }

      //  if (Input.GetMouseButtonDown(0))
     //   {
            //BuildRoom();
     //   }

    }

   // void BuildRoom()
   // {
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    Vector3 point = ray.GetPoint(distance);
    //    GameObject Room = Instantiate(Cube, point, Quaternion.identity);
    //    Room.transform.parent = Moon_As_Parent;
    //}
}
