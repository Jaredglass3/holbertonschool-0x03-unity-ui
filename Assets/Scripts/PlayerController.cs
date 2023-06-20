using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int score = 0;
    public int health = 5;
    public Rigidbody m_Rigidbody;
    public float speed = 700;
    public Text scoreText;
    public Text healthText;
    public Image WinLoseImage;
    public Text WinLoseText;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            WinLoseText.text = "Game Over!";
            WinLoseText.color = Color.white; 
            WinLoseImage.color = Color.red;
            WinLoseImage.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
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
            SetHealthText();
        }
        if (other.gameObject.tag == "Pickup")
        {
            score += 1;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Goal")
        {
            WinLoseText.text = "You Win!";
            WinLoseText.color = Color.black; 
            WinLoseImage.color = Color.green;
            WinLoseImage.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}