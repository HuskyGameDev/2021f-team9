using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        yourButton.GetComponent<Button>();
        yourButton.onClick.AddListener(onClick);

    }

    public void onClick()
    {
        Application.Quit();
    }
}
