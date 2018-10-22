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

    public int score;
    public int lives;

    public float speed;

    private Rigidbody m_rigidbody;
    public Boundary m_boundary;

    public GameObject m_shot;
    public Transform m_shotSpawn;
    public float m_fireRate;

    private float m_nextFire;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_nextFire = 0;
        updateText();
        score = 0;
        lives = 3;

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > m_nextFire)
        {
            m_nextFire = Time.time + m_fireRate;
            Instantiate(m_shot, m_shotSpawn.position, m_shotSpawn.rotation);
        }

        updateText();

    }




    void FixedUpdate()
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
        }
        else if (lives > 0)
        {
            gameOverText.text = "";
        }
    }


}
