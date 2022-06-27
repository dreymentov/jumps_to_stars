using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_Movements : MonoBehaviour
{
    public float speed;
    public float powerJump;

    public float positionDeath;
    public float maxHeightDeath;
    public float maxHeightLevel = 37f;

    public Rigidbody2D playerRB;

    public GameObject player;

    public GameObject deathPlayer;

    public bool isGroundedPlayer = false;
    public bool falling = false;

    public bool jumped;

    public bool gaming;


    // Start is called before the first frame update
    void Start()
    {
        gaming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gaming)
        {
            Time.timeScale = 1;
            playerRB.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f));

            if ((Input.GetButtonDown("Jump") == true) && (player.GetComponent<CircleCollider2D>().enabled = true))
            {
                jumped = true;
            }

            if (player.transform.position.y > maxHeightLevel)
            {
                player.transform.position = new Vector2(player.transform.position.x, maxHeightLevel);
                playerRB.velocity = new Vector2(0, 0);
            }

            if(Input.GetKeyDown("escape"))
            {
                gaming = false;
            }
        }
        else
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown("escape"))
            {
                gaming = true;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "ground") && (player.GetComponent<CircleCollider2D>().enabled = true))
        {
            isGroundedPlayer = true;
        }

        if(collision.gameObject.tag == "death")
        {
            SceneManager.LoadScene("level1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGroundedPlayer = false;
        }
    }


    private void FixedUpdate()
    {
        if(playerRB.velocity.y > powerJump)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, powerJump);
        }

        if ((jumped == true) && (isGroundedPlayer == true))
        {
            playerRB.AddForce(Vector2.up * powerJump, ForceMode2D.Impulse);
            jumped = false;
        }
    }

    private void LateUpdate()
    {
        if (playerRB.velocity.y > 0.3f)
        {
            player.GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (playerRB.velocity.y < -0.3f)
        {
            player.GetComponent<CircleCollider2D>().enabled = true;

            if (isGroundedPlayer == false)
            {
                falling = true;
            }
            else falling = false;
        }
        else player.GetComponent<CircleCollider2D>().enabled = true;

        if (isGroundedPlayer == true)
        {
            if (deathPlayer.transform.position.y + maxHeightDeath < player.transform.position.y)
            {
                deathPlayer.transform.position = new Vector2(0, player.transform.position.y - maxHeightDeath);
            }
        }


    }
}
