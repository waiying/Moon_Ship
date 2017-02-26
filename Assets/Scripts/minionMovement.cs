using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionMovement : MonoBehaviour {
    public float moveSpeed;
    public Vector3 homePos;
    private float timer = 10.0f;
    private int[] i = new int[] { -1, 1 };
    private int leftRight;
    private bool isCoroutineExecuting = false, shouldMove = false, collecting = false;

    void Start () {
        transform.position = homePos; // set minion to be at home position
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position == homePos)
        {
            leftRight = i[Random.Range(0, i.Length)]; //randomly choose left or right; 1 = right, -1 left
            StartCoroutine(MoveOutside()); //wait about 3 seconds before moving out
        }

        if (shouldMove)
        {
            transform.Translate(moveSpeed * leftRight * Time.deltaTime, 0f, 0f);
        }

        if (collecting)
        {
            timer -= Time.deltaTime; //timer countdown
            print(timer);
        }

        if (timer <= 0)
        {
            collecting = false;
            transform.position = Vector3.MoveTowards(transform.position, homePos, 0);
        }

	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "item") //minion stops moving when it touches the item
        {
            transform.Translate(new Vector3(0, 0, 0));
            shouldMove = false;
            collecting = true;
            timer -= Time.deltaTime;
        }
    }

    IEnumerator MoveOutside()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(3);

        shouldMove = true;
        print(leftRight);
        transform.Translate(moveSpeed * leftRight * Time.deltaTime, 0f, 0f);
        //print(transform.position);
    }
}
