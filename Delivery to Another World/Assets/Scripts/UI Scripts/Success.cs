using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Success : MonoBehaviour
{

    public Image missionCompleteImage;

    private bool success;

    // Start is called before the first frame update
    void Start()
    {
        success = false;
    }

    public void youWin()
    {
        success = true;
    }

    void FixedUpdate()
    {
        if (success)
        {
            missionCompleteImage.color = new Color(255f, 255f, 255f, Mathf.Lerp(missionCompleteImage.color.a, 1f, Time.deltaTime / 3f));
        }
    }
}
