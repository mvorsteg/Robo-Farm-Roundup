using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;
    public Text buttonText;
    private static int slideNum;

    // Start is called before the first frame update
    void Start()
    {
        slideNum = 1;
        slide1.SetActive(true);
        slide2.SetActive(false);
        slide3.SetActive(false);
    }

    public void NextSlide()
    {
        if (slideNum == 1)
        {
            slide1.SetActive(false);
            slide2.SetActive(true);
            slideNum++;
        }
        else if (slideNum == 2)
        {
            slide2.SetActive(false);
            slide3.SetActive(true);
            slideNum++;
            buttonText.fontSize = 50;
            buttonText.text = "back to\nmenu";

        }
        else
        {
            slideNum = 0;
            SceneManager.LoadScene("Menu");
        }
    }
}
