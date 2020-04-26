using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child : MonoBehaviour
{
    public GameObject red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        red.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        red.GetComponent<Rigidbody>().AddRelativeTorque(0, 0, -2000);
        red.GetComponent<red>().flag = false;
        
    }
}
