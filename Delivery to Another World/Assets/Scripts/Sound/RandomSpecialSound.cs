using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpecialSound : MonoBehaviour
{

    private float randomNum;
    private bool wait;

    // Start is called before the first frame update
    void Start()
    {
        wait = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait)
        {
            StartCoroutine(CountdownXD());
        }
    }

    IEnumerator CountdownXD()
    {
        wait = true;
        randomNum = Random.Range(38f, 200f);
        yield return new WaitForSeconds(randomNum);
        GetComponent<AudioSource>().Play();
        wait = false;
    }
}
