using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class gameManager1 : MonoBehaviour
{

    public GameObject Menu;
    public GameObject player;
    public GameObject platforms;
    public GameObject platformToWin;

    public int level1 = 7;

    // Start is called before the first frame update
    void Start()
    {
        Startlevel();  
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<player_Movements>().gaming == true)
        {
            Menu.SetActive(false);
        }
        if (player.GetComponent<player_Movements>().gaming == false)
        {
            Menu.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();

        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void StartGame()
    {
        player.GetComponent<player_Movements>().gaming = true;

    }

    public void Startlevel()
    {
        int randomX = 0;

        for (int i = 0; i < level1; i++)
        {
            if(i == 0)
            {
                platforms.transform.position = new Vector2(randomX, i * 3f);
            }
            else
            platforms.transform.position = new Vector2(randomX + Random.Range(-4, 4), i * 3f);
            Instantiate(platforms, platforms.transform);
        }

        platformToWin.transform.position = new Vector2(randomX + Random.Range(-4, 4), level1 * 3f);
        Instantiate(platformToWin, platformToWin.transform);
    }

    public void Restarted()
    {
        Startlevel();
    }
}
