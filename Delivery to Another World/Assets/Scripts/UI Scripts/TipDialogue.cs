using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipDialogue : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            enabled = false;
        }
    }
}
