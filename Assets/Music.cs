using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSrc;

    private static Music instance = null;
    public static Music Instance
    {
        get { return instance; }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
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
