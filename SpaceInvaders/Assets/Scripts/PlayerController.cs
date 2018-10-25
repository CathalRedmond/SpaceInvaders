using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class PlayerController : MonoBehaviour
{
 
    public Text scoreText;
    public Text livesText;
    public Text gameOverText;

    public AudioSource shotSound;
    public AudioSource playerKilledSound;
    public AudioSource invaderKilledSound;
    public AudioSource bunkerHitSound;

    private bool playPlayerKilledSound;

    public int score;
    public int lives;

    public float speed;

    private Rigidbody m_rigidbody;
    public Boundary m_boundary;

    public GameObject m_shot;
    public Transform m_shotSpawn;
    public float m_fireRate;

    private float m_nextFire;

    private double invulnerabilityStartTime;

    private int flashColourValue;


    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_nextFire = 0;
        updateText();
        score = 0;
        lives = 3;
        playPlayerKilledSound = true;
        invulnerabilityStartTime = 0;
        flashColourValue = 0;
    }

    void Update()
    {
        if (lives > 0)
        {
            if (Input.GetKeyDown("space") && Time.time > m_nextFire)
            {
                m_nextFire = Time.time + m_fireRate;
                Instantiate(m_shot, m_shotSpawn.position, m_shotSpawn.rotation);
                shotSound.Play();
            }
        }

        updateText();
        if (invulnerabilityStartTime != 0)
        {
            if (Time.realtimeSinceStartup - invulnerabilityStartTime > 3)
            {
                GetComponent<Collider>().enabled = true;
                GetComponent<MeshRenderer>().enabled = true;

                invulnerabilityStartTime = 0;
                GetComponent<Renderer>().material.color = Color.green;
                flashColourValue = 0;

            }
            else
            {
                if (flashColourValue % 2 == 0)
                {
                    GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    GetComponent<MeshRenderer>().enabled = false; 
                }
                flashColourValue++;
            }
        }
    }
    
    void FixedUpdate()
    {
        if (lives > 0)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            m_rigidbody.AddForce(movement * speed);

            m_rigidbody.position = new Vector3
            (
                Mathf.Clamp(m_rigidbody.position.x, m_boundary.xMin, m_boundary.xMax),
                0.0f,
                0.0f
            );
        }
    }

    void updateText()
    {

        scoreText.text = "Score: " + score ;
        livesText.text = "Lives: " + lives;


        if(GameObject.FindGameObjectsWithTag("Invader").Length <= 0)
        {
            gameOverText.text = "You Win";
        }
        else if (lives <= 0)
        {
            gameOverText.text = "Game Over";

            if(playPlayerKilledSound)
            {
                playPlayerKilledSound = false;
                playerKilledSound.Play();
            }
        }
        else if (lives > 0)
        {
            gameOverText.text = "";
            playPlayerKilledSound = true;
        }
    }

    public void restart()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        m_rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);



        
        
        GetComponent<Collider>().enabled = false;


        invulnerabilityStartTime = Time.realtimeSinceStartup;

        // become invulnerable here
    }
}
