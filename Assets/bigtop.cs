using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigtop : MonoBehaviour
{
    private bool flag = true;
    public GameObject bigRed;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("START");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision other)
    {
        if (flag)
        {
            
            if (other.gameObject.CompareTag("Player") && bigRed.GetComponent<bigred>().flag)
            {
                flag = false;
                transform.gameObject.tag = "dead";
                StartCoroutine(bigRed.GetComponent<bigred>().Die());
            }
        }
    }
}
