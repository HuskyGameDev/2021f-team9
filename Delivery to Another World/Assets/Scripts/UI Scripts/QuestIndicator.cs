using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIndicator : MonoBehaviour
{

    public GameObject questButton1;
    public GameObject questButton2;

    // Update is called once per frame
    void Update()
    {
        if (!questButton1.activeSelf && !questButton2.activeSelf)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
