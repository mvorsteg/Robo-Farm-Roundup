using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scripty : MonoBehaviour
{
    private const float maxFuel = 1.5f;
    public GameObject cameras;
    public AudioSource valkyrie;
    public AudioSource music;
    public AudioSource scream;
    private GameObject sadMusic;
    public Slider fuelBar;
    public float speed;
    public float jetpackForce;
    private float rotationSpeed;
    public bool flag;
    private Rigidbody rb;
    private GameObject happyMusic;
    public GameObject big;
    public Text wrangler;
    public GameObject go;
    public GameObject jetpack;
    public GameObject particles;
    public GameObject scoreBoard;
    private float fuel;
    private int kills;
    public GameObject gameOver;
    public Text txt;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        happyMusic = GameObject.FindGameObjectWithTag("Music");
        happyMusic.GetComponent<Music>().StopMusic();
        sadMusic = GameObject.FindGameObjectWithTag("Music2");
        rotationSpeed = 0.05F;
        red.maxSpeed = 0.04F;
        cameras.GetComponent<cameras>().overhead.enabled = false;
        particles.GetComponent<ParticleSystem>().Stop();
        fuel = maxFuel;
        flag = true;
        rb = GetComponent<Rigidbody>();
        time = 0;
        fuelBar.value = CalculateFuel();
        kills = 0;
       
        // rb.AddRelativeForce(40, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if (time > 1)
        {
            time = 0;
            if (Random.Range(0,50) == 0)
            {
               Instantiate(big);
            }
            else
            {
               Instantiate(go);
            }
            
        }
        if (flag)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                cameras.GetComponent<cameras>().OverView();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                cameras.GetComponent<cameras>().SideView();
            }

            if (transform.position.y < -10)
                Die();
            //rb.position -= new Vector3((transform.right * speed).x, 0, (transform.right * speed).z);

            if (Input.GetKey(KeyCode.S))
            {
                transform.position += transform.right * speed * Time.deltaTime;
                //rb.position -= new Vector3((transform.right * speed).x, 0, (transform.right * speed).z);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, speed * 20 * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, speed * -20 * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.Space) && fuel > 0)
            {
                if (valkyrie.isPlaying == false)
                {
                    valkyrie.Play();
                    music.Pause();
                }

                fuelBar.value = CalculateFuel();
                jetpack.GetComponent<Rigidbody>().AddForce(0, jetpackForce * Time.deltaTime, 0);
                GetComponent<Rigidbody>().AddForce(0, jetpackForce * Time.deltaTime, 0);
                fuel -= Time.deltaTime;
                
            }
            if (Input.GetKeyDown(KeyCode.Space) && fuel > 0)
            {
                particles.GetComponent<ParticleSystem>().Play();

            }
            if (Input.GetKeyUp(KeyCode.Space) || fuel == 0)
            {
                particles.GetComponent<ParticleSystem>().Stop();
            }

            /*if (Input.GetKeyDown(KeyCode.X))
                loop(50, Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000));

            if (Input.GetKeyDown(KeyCode.Z))
            {
                loop(50, 0, -1000, 0);
                rb.AddRelativeTorque(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000));
            }

            if (Input.GetKey(KeyCode.R))
            {
                rb.position = new Vector3(0, 10, 0);
                rb.velocity = new Vector3(0, 0, 0);
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }*/
        }
    }

    void loop(int i, int x, int y, int z)
    {
        rb.AddRelativeForce(x, y, z);
    }

    float CalculateFuel()
    {
        return fuel / maxFuel;
    }

    public void score()
    {
        if (flag)
        {
            if (rotationSpeed < 0.1F)
            {
                speed += 0.004F;
                rotationSpeed += 0.001F;
            }
            kills++;
            wrangler.text = "" + kills;
        }
    }

    void OnCollisionStay(Collision other)
    {
        /*if (other.gameObject.CompareTag("ugly"))
        {
            flag = false;
            rb.AddExplosionForce(1000, other.gameObject.GetComponent<Transform>().position, 10);
        }*/
        //Debug.Log("Touched");
        if ((other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("dead")) && fuel < maxFuel && flag)
        {
            if (valkyrie.isPlaying)
            {
                valkyrie.Stop();
               
            }
            if (music.isPlaying == false)
                music.Play();
            //Debug.Log("Refueling");
            fuel += Time.deltaTime;
            fuelBar.value = CalculateFuel();
        }
    }

    /*void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bigTop")){
            Debug.Log("HELLW");
            other.gameObject.GetComponent<bigtop>().kill();
        }
    }*/

    public void Die()
    {
        flag = false;
        valkyrie.Stop();
        music.Stop();
        
        GetComponent<Transform>().gameObject.tag = "deadPlayer";
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().AddExplosionForce(1000, GetComponent<Transform>().position, 10);
        scream.Play();
        happyMusic.GetComponent<Music>().StopMusic();
        sadMusic.GetComponent<Music2>().PlayMusic();
        if (kills == 0)
            txt.text = "You're not a real cowboy";
        else if (kills == 1)
            txt.text = "You killed " + kills + " robot";
        else
            txt.text = "You killed " + kills + " robots";
        gameOver.SetActive(true);
        //scoreBoard.GetComponent<leaderboards>().myPoints = kills;
        //cameras.GetComponent<cameras>().flag = true;
        //Debug.Log("dies");
        leaderboards.newScore = kills;
        StartCoroutine(cameras.GetComponent<cameras>().camera1());

    }

    

}
