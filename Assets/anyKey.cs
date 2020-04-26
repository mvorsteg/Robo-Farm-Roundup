using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anyKey : MonoBehaviour
{

    public GameObject game;
    public GameObject panel;
    public GameObject control;
    public Camera cam;
    public GameObject endPanel;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("LLSDASD");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Leaderboards");
            
        }
    }
}
