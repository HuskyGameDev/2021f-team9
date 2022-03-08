using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimensionIndicator : MonoBehaviour
{

    private bool dimensionActive;
    private Color dimZ;
    private Color dimX;

    // Start is called before the first frame update
    void Start()
    {
        dimZ = new Color(1f/255f*150f, 0f, 0f); // Dark red
        dimX = new Color(0f, 0f, 1f/255f*150f); // Dark blue
    }

    // Update is called once per frame
    void Update()
    {
        dimensionActive = FindObjectOfType<RotationGravity>().dimensionActive;

        if (dimensionActive)
        {
            GetComponent<Text>().text = "DIMENSION Z";
            GetComponent<Text>().color = dimZ;
        }
        else
        {
            GetComponent<Text>().text = "DIMENSION X";
            GetComponent<Text>().color = dimX;
        }
    }

    public void showDimension()
    {
        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(3f);
        GetComponent<Text>().enabled = false;
    }
}
