using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRoomButtons : MonoBehaviour
{

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject box;

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
            Camera.main.transform.LookAt(GameObject.FindGameObjectWithTag("GEOFFRY").transform);
            box.SetActive(true);
            // Roll credits
            StartCoroutine(WaitForCredits());
            Debug.Log("All buttons pressed.");
        }
    }

    private IEnumerator WaitForCredits()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Credits");
    }
}
