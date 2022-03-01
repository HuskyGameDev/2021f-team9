using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwoosh : MonoBehaviour
{

    public AudioSource swooshSound;
    public float timetoplay;
    private bool canturn;

    public RotationGravity rotationgrav;

    // Start is called before the first frame update
    void Start()
    {
        swooshSound = GetComponent<AudioSource>();
        
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
