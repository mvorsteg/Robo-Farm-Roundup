using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigred : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Rigidbody rb;
    public bool flag;
    public GameObject prefab;
    public GameObject particles;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.position = new Vector3(Random.Range(-30, 30), 25, Random.Range(-30, 30));
        transform.localScale = new Vector3(Random.Range(4, 10), Random.Range(4, 10), Random.Range(4, 10));


        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            player = GameObject.FindWithTag("deadPlayer");
        }

        flag = true;


        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.gameObject.GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, 0);
        transform.gameObject.tag = "ugly";
        speed = Random.Range(2.3F, 5F);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            if (transform.position.y < -10)
                Die();
            float x = transform.localEulerAngles.x;
            float z = transform.localEulerAngles.z;
            transform.LookAt(player.GetComponent<Transform>());
            float y = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(x, y + 90, z);
            rb.position -= new Vector3((transform.right * speed * Time.deltaTime).x, 0, (transform.right * speed * Time.deltaTime).z);
        }
    }
    //transform.Rotate(0, 0, 0);



    public IEnumerator Die()
    {
        //Debug.Log("DIE");
        //GetComponent<AudioSource>().Play();
        flag = false;
        
        //rb.constraints = RigidbodyConstraints.None;
        //rb.AddExplosionForce(1000, player.GetComponent<Transform>().position, 10);
        //rb.AddRelativeTorque(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000));
        transform.gameObject.tag = "dead";
        
        player.GetComponent<scripty>().score();
        yield return new WaitForSeconds(2);
        particles.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1F);
        prefab.SetActive(false);
        yield return new WaitForSeconds(3);
        particles.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.2F);
        Destroy(gameObject);

    }

}
