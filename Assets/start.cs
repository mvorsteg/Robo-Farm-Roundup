using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class start : MonoBehaviour
{
    private GameObject happyMusic;
    private GameObject sadMusic;
    void Start()
    {
        happyMusic = GameObject.FindGameObjectWithTag("Music");
        happyMusic.GetComponent<Music>().PlayMusic();
        sadMusic = GameObject.FindGameObjectWithTag("Music2");
        sadMusic.GetComponent<Music2>().StopMusic();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
