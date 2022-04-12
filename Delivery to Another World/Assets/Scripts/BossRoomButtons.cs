using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomButtons : MonoBehaviour
{

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    bool oneButtonClicked = false;
    bool twoButtonClicked = false;
    bool allButtonsClicked = false;

    public void pressedNextButton()
    {
        if(!oneButtonClicked)
        {
            oneButtonClicked = true;
        }
        else if (!twoButtonClicked)
        {
            twoButtonClicked = true;
        }
        else if(!allButtonsClicked)
        {
            allButtonsClicked = true;
            //Cutscene
            Debug.Log("All buttons pressed.");
        }
    }
}
