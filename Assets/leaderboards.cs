using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class leaderboards : MonoBehaviour
{
    public score[] highScores;

    public class score
    {
        int points;
        string name;

        public score(int pts, string nm)
        {
            points = pts;
            name = nm;
        }

        public int getPoints()
        {
            return points;
        }

        public string getName()
        {
            return name;
        }


    }

    private GameObject happyMusic;
    private GameObject sadMusic;
    public Text names;
    public GameObject input;
    public Text button;
    public Text inputText;
    public Text wrangler;
    public static int newScore;
    //public TextField box;



    // Start is called before the first frame update
    void Start()
    {
        happyMusic = GameObject.FindGameObjectWithTag("Music");
        sadMusic = GameObject.FindGameObjectWithTag("Music2");
        highScores = new score[10];
        Load();
        if (highScores[9] != null && highScores[9].getPoints() >= newScore)
        {
            input.SetActive(false);
            button.text = "Play again";
            button.fontSize = 54;
        }
        else
        {
            sadMusic.GetComponent<Music2>().StopMusic();
            happyMusic.GetComponent<Music>().PlayMusic();
        }
        wrangler.text = "You Wrangled\n" + newScore + " bots!";
        // Debug.Log(highScores[4]);
        DisplayScores();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        //Debug.Log(newScore);
        int score = newScore;
        string name = input.GetComponent<InputField>().text;
        if (name.Length < 1)
            name = "anonymous";
        else if (name.Length > 16)
            name = name.Substring(0, 15);
        bool search = true;
        int i = 0;
        score[] newScores = new score[10];
        
        while (i < 10 && search)
        {
            //Debug.Log(i);
            if (highScores[i].getName() == "") 
            {
                //Debug.Log(name);
                newScores[i] = new score(score, name);
                search = false;
                i++;
                while (i < 10)
                {
                    //Debug.Log(i);
                    newScores[i] = new leaderboards.score(0,"");
                    i++;
                }

            }
            else if (score > highScores[i].getPoints())
            {
                search = false;
                newScores[i] = new score(score, name);
                i++;
                while (i < 10)
                {
                    //Debug.Log(i);
                    newScores[i] = highScores[i - 1];
                    i++;
                }
            }
            else
                newScores[i] = highScores[i];
            i++;
        }
        //Debug.Log(newScores[0].getName());
        highScores = newScores;
        //Debug.Log(highScores[0].getName());
        

        /*for(int p=0; p<10; p++)
        {
            string str;
            if (highScores[p] != null)
            {
                str = p + highScores[p].getName() + " " + highScores[p].getPoints();
                Debug.Log(str);
            }
        }*/
        Save();
        SceneManager.LoadScene("Menu");
    }
    void Load()
    {
        //Debug.Log("LOAD");
        for (int i=0; i<10; i++)
        {
            highScores[i] = new score(PlayerPrefs.GetInt("HSPoints" + i),PlayerPrefs.GetString("HSName" + i));
        }
    }

    void Save()
    {
        for(int i=0; i<10; i++)
        {
            PlayerPrefs.SetInt("HSPoints" + i, highScores[i].getPoints());
            PlayerPrefs.SetString("HSName" + i, highScores[i].getName());
        }
    }

    public override string ToString()
    {
        string highScoreString = "";
        for(int i=0; i<10; i++)
        {
            highScoreString += i+1;
            if (i < 9)
                highScoreString += "  ";
            highScoreString += ": ";
            if (highScores[i] != null)
            {
                //Debug.Log(i);
                highScoreString += highScores[i].getName() + " " + highScores[i].getPoints();
            }
            highScoreString += "\n";
        }
        return highScoreString;
    }

    public void DisplayScores()
    {
        names.text = ToString();
    }
    public void ClearScores()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt("HSPoints" + i, 0);
            PlayerPrefs.SetString("HSName" + i, "");
        }
    }

}
