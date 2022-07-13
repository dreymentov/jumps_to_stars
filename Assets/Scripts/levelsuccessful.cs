using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelsuccessful : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (Player.GetComponent<Rigidbody2D>().velocity.y == 0))
        {
            Invoke("Restart", 1);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("level1");
        Invoke("Restarted", 0.2f);
    }
}
