using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    Animator anim;
    public float speed;
    public Text livesText;
    public Text score;
    public Text winText;

    private float lastHit;
    private int Lives = 3;
    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Score:" + scoreValue.ToString();
        winText.text = "";
        livesText.text = "Lives: " + Lives;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            rd2d.AddForce(new Vector2(hozMovement * speed - hozMovement, vertMovement * speed));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();

        }
        if (scoreValue == 4)
        {
            ToLevelTwo();
        }
        else if (scoreValue == 8)
        {
            winText.text = "You have Won! Created By Nathan Pluskota";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {

            setLivesCount();
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("Idle", 3);
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
            }
        }
    }
    void setLivesCount()
    {
        Lives = Lives - 1;
        livesText.text = "Lives: " + Lives;

        if (Lives <= 0)
        {
            winText.text = "You have lost, Please Reattempt by Quitting and Relauching";
            Destroy(gameObject);
        }
    }
    void ToLevelTwo()
    {
        transform.position = new Vector2(120, 2);
        Lives = 3;
        livesText.text = "Lives: " + Lives;
    }
}
   
