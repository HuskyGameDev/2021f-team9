using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwoosh : MonoBehaviour
{

    public AudioSource swooshSound;
    public float timetoplay;

    // Start is called before the first frame update
    void Start()
    {
        swooshSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            PlayForTime(timetoplay);
        }
    }

    //Play the sound for time ammount of time
    public void PlayForTime(float time)
    {
        swooshSound.time = .561f;
        swooshSound.Play();
        Invoke("StopAudio", time);
    }

    //Stop the audio
    private void StopAudio()
    {
        swooshSound.Stop();
    }
}
