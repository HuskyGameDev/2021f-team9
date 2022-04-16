using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenWall : MonoBehaviour
{

    public void OpenWall()
    {
        transform.localScale = new Vector3(19f, 10f, 1f);
        transform.position = new Vector3(0f, 5f, -19.5f);
    }

    public void CloseWall()
    {
        transform.localScale = new Vector3(20f, 10f, 1f);
        transform.position = new Vector3(0f, 5f, -20f);
    }
}
