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
    {
     m_Rigidbody = GetComponent<Rigidbody>();
    }

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
         float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        m_Rigidbody.velocity = movement * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
          health--;
            Debug.Log("Health: " + health);
        }
        if (other.gameObject.tag == "Pickup")
        {
           score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Goal")
        {
        Debug.Log("You win!");
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