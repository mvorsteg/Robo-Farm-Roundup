using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour
{
    public GameObject go;
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
        if (other.gameObject.CompareTag("ugly") && go.GetComponent<scripty>().flag)
        {
            //Debug.Log("GGG");
            go.GetComponent<scripty>().Die();
        }
    }
}
