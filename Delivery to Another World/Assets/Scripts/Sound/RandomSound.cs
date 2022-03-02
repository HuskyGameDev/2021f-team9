using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    private AudioSource randSound;
    public AudioClip[] sounds;
    public float timetoplay;
    float timer;

    // Start is called upon initilization
    void Start()
    {
        timer = 0f;
        randSound = GetComponent<AudioSource>();
    }

    //Update is called every frame
    void Update()
    {
        //inctiment time every ms
        timer += Time.deltaTime;

        //Turn that into seconds
        int seconds = (int) timer % 60;

        //if seconds is devisiable by 6 play sound for x seconds
        if ((seconds % 8) == 0 && seconds != 0)
        {
            PlayForTime(timetoplay);
        }


    }

    //Play the sound for time ammount of time
    public void PlayForTime(float time)
    {
        randSound.clip = sounds[Random.Range(0, sounds.Length)];
        randSound.Play();
        Invoke("StopAudio", time);
    }

    //Stop the audio
    private void StopAudio()
    {
        randSound.Stop();
    }

}
