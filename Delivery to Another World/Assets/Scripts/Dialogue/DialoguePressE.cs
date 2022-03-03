using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePressE : MonoBehaviour
{

    public void showE()
    {
        GetComponent<Text>().enabled = true;
    }

    public void hideE()
    {
        GetComponent<Text>().enabled = false;
    }

    public void changeToR()
    {
        GetComponent<Text>().text = "Press R";
    }

    public void changeToE()
    {
        GetComponent<Text>().text = "Press E";
    }

    public void changeToShift()
    {
        GetComponent<Text>().text = "Press Shift While Moving";
    }

}
