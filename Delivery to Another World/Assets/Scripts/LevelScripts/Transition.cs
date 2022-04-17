using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    private bool changeRoom;
    int count = 0; // prevents an infinite loop (just in case (PTSD))

    // Start is called before the first frame update
    void Start()
    {
        changeRoom = false;
        transition();
    }

    // fades screen to black when transitioning between rooms
    public void transition()
    {
        StartCoroutine(TransitionEffect());
        while (count<20)
        {
            if (changeRoom)
            {
                break;
            }
            count++;
        }
        changeRoom = false;
        count = 0;
    }

    private IEnumerator TransitionEffect()
    {
        Color canvasColor = GetComponent<Image>().color;
        while (GetComponent<Image>().color.a < 1)
        {
            canvasColor.a += Time.deltaTime/2;
            GetComponent<Image>().color = canvasColor;
        }
        changeRoom = true;
        while (canvasColor.a > 0)
        {
            canvasColor.a -= Time.deltaTime/2;
            GetComponent<Image>().color = canvasColor;
            yield return null;
        }
    }
}
