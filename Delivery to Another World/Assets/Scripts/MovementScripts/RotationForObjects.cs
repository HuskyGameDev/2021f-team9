using System.Collections;
using UnityEngine;

public class RotationForObjects : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // This is all I had to do... big sad. I made it way more complex than it needed to be.
        transform.rotation = FindObjectOfType<RotationGravity>().transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = FindObjectOfType<RotationGravity>().transform.rotation;
    }
}
