using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music2 : MonoBehaviour
{
    private AudioSource audioSrc;

    private static Music2 instance = null;
    public static Music2 Instance
    {
        get { return instance; }
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;

        }
        DontDestroyOnLoad(this.gameObject);
    }
    /*private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSrc = GetComponent<AudioSource>();
    }*/

    public void PlayMusic()
    {
        if (audioSrc.isPlaying == false)
        {
            audioSrc.Play();
        }
    }

    public void StopMusic()
    {
        //Debug.Log("Stopped");
        if (audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }
    }
}
