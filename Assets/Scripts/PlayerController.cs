using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int score = 0;
    public int health = 5;
    public Rigidbody m_Rigidbody;
    public float speed = 700;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
            m_Rigidbody.AddForce(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("a"))
            m_Rigidbody.AddForce(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("w"))
            m_Rigidbody.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("s"))
            m_Rigidbody.AddForce(0, 0, -speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            Debug.Log("Health: " + health);
        }
        if (other.gameObject.tag == "Pickup")
        {
            score += 1;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }

    void ZeroHealth(Collider other)
    {
    }
}