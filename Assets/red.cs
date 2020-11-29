using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour
{
    public GameObject player;
    public GameObject particles;
    public float speed;
    public float jetpackForce;
    public static float maxSpeed = 2.3F;
    private Rigidbody rb;
    public bool flag;
    private bool jetpack = false;
    private bool jumpy = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.position = new Vector3(Random.Range(-45, 45), 5, Random.Range(-45, 45));
        transform.localScale = new Vector3(Random.Range(0.5F, 1.5F), Random.Range(0.5F, 1.5F), Random.Range(0.5F, 1.5F));
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            player = GameObject.FindWithTag("deadPlayer");
        }
        if (Random.Range(0,20) == 0)
        {
            jetpack = true;
            particles.SetActive(true);
        }
        else if(Random.Range(0,20) == 0)
        {
            jumpy = true;
        }
        
        flag = true;
       
        
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.gameObject.GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, 0);
        transform.gameObject.tag = "ugly";
        maxSpeed += 0.05F;
        speed = Random.Range(2.3F, maxSpeed);
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
           
            if (jetpack)
            {
                if(player.GetComponent<Transform>().position.y > transform.position.y && player.GetComponent<Transform>().position.y > 2.5)
                {
                    //Debug.Log(player.GetComponent<Transform>().position.y);
                    GetComponent<Rigidbody>().AddForce(0, jetpackForce * Time.deltaTime, 0);
                    if (particles.GetComponent<ParticleSystem>().isPlaying == false)
                    {
                        particles.GetComponent<ParticleSystem>().Play();
                    }
                }
                else
                {
                    if (particles.GetComponent<ParticleSystem>().isPlaying == true)
                    {
                        particles.GetComponent<ParticleSystem>().Stop();
                    }
                }

            }

            transform.localEulerAngles = new Vector3(x, y + 90, z);
            rb.position -= new Vector3((transform.right * speed * Time.deltaTime).x, 0, (transform.right * speed * Time.deltaTime).z);
        }
    }
    //transform.Rotate(0, 0, 0);



        private void Die()
    {
        GetComponent<AudioSource>().Play();
        flag = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddExplosionForce(1000, player.GetComponent<Transform>().position, 10);
        rb.AddRelativeTorque(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000));
        transform.gameObject.tag = "dead";
        player.GetComponent<scripty>().score();
        Destroy(gameObject, 5.0F);
    }


    void OnCollisionEnter(Collision other)
    {
        if (jumpy)
        {
            for(int i=0; i<10; i++)
            {
                GetComponent<Rigidbody>().AddForce(0, 25, 0);
            }
        }

        if (other.gameObject.CompareTag("Player") && flag)

            Die();
        
    }
}
