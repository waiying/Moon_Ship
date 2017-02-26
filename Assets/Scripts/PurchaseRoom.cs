using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseRoom : MonoBehaviour {

    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        //yourButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
       // yourButton.GetComponentInChildren<Text>().color = Color.clear;

    }

    public void TaskOnClick()
    {
        //yourButton.enabled = false;
        //yourButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        //yourButton.GetComponentInChildren<Text>().color = Color.clear;
        Debug.Log("You have clicked the button!");
    }

}
