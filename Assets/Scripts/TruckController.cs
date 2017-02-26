using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour {

    public float moveSpeed;
    //private Vector3 moveDir;
    private Rigidbody rb;
    private float totalTimeOutside = 10f;
    private float stayInsideTime;
    private float collectTimer = 2f;
    private float[] timeList = new float[] { 1f, 2f, 3f, 4f, 5f};
    private float moveSec;
    private bool moving = true, collecting = false, rotate = true, homeBound = false, nowInside = false;

    private void Start()
    {
        moveSec = timeList[Random.Range(0, timeList.Length)];
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        totalTimeOutside -= Time.deltaTime;

        if (collecting)
        {
            collectTimer -= Time.deltaTime;
        }
        if (collectTimer <= 0)
        {
            if (totalTimeOutside > 0)
            {
                moving = true; // start moving again
                collectTimer = 2f; // reset timer for next time
            }
            collecting = false;
        }
        if (totalTimeOutside <= 0)
        {
            //goes back to base
            if (!collecting && !nowInside)
            {
                moving = true;
                homeBound = true;
                collectTimer = 2f;
                moveSec = timeList[Random.Range(0, timeList.Length)];
            }
        }

        if (stayInsideTime > 0 && nowInside)
        {
            stayInsideTime -= Time.deltaTime;
        }

        if (stayInsideTime < 0 && nowInside)
        {
            nowInside = false;
            homeBound = false;
            rotate = true;
            totalTimeOutside = 10f;
            moving = true;
            stayInsideTime = 5f;
        }
    }

    private void FixedUpdate()
    {

        if (moving)
        {
            if (totalTimeOutside > 0)
            {
                rb.velocity = -transform.forward * moveSpeed;
                moveSec -= Time.deltaTime;
            } else if (homeBound)
            {
                if (rotate)
                {
                    transform.Rotate(0, 180, 0);
                    rotate = false;
                }
                rb.velocity = -transform.forward * moveSpeed;
            }
            
        } else //not moving
        {
            rb.velocity = Vector3.zero;

        }

        if (moveSec <= 0 && totalTimeOutside > 0)
        {
            moving = false;
            collecting = true;
            moveSec = timeList[Random.Range(0, timeList.Length)]; // repick moving time
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "home" && homeBound)
        {
            InstantiateTruck.numResources += 1;
            
            print(InstantiateTruck.numResources);
            moving = false;
            transform.Rotate(0, 180, 0); // rotate back for next round
            stayInsideTime = 5f;
            nowInside = true;            

            //Destroy(this.gameObject);
        }

        if (collision.collider.tag == "truck")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
