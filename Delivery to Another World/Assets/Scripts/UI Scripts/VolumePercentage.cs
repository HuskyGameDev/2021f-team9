using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumePercentage : MonoBehaviour
{

    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = Mathf.Ceil(slider.value).ToString() + "%";
    }
}
