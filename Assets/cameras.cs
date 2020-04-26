using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameras : MonoBehaviour
{
    public int flag;
    public Camera view;
    public Camera overhead;
    public GameObject anyKey;
    // Start is called before the first frame update
    void Start()
    {
        overhead.enabled = false;
        view.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OverView()
    {
        overhead.enabled = true;
        view.enabled = false;
    }

    public void SideView()
    {
        overhead.enabled = false;
        view.enabled = true;
    }

    public IEnumerator camera1()
    {
        //Debug.Log("HETRE");
    Label:
        yield return new WaitForSeconds(2);
        anyKey.SetActive(true);
        yield return new WaitForSeconds(8);
        overhead.enabled = true;
        view.enabled = false;
        //Debug.Log("END");
        yield return new WaitForSeconds(10);
        overhead.enabled = false;
        view.enabled = true;
        goto Label;
    }
}
