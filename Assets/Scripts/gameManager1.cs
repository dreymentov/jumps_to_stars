using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class gameManager1 : MonoBehaviour
{

    public GameObject Menu;
    public GameObject Player;
    public GameObject Platforms;
    public GameObject PlatformToWin;
    public Vector2 Pos2;

    public int level1 = 7;

    // Start is called before the first frame update
    void Start()
    {
        Startlevel();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<player_Movements>().gaming == true)
        {
            Menu.SetActive(false);
        }
        if (Player.GetComponent<player_Movements>().gaming == false)
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
        Player.GetComponent<player_Movements>().gaming = true;

    }

    public void Startlevel()
    {
        int randomX = 0;

        for (int i = 0; i < level1; i++)
        {
            if(i == 0)
            {
                Pos2 = new Vector2(randomX, i * 3f);
            }
            else
                Pos2 = new Vector2(randomX + Random.Range(-4, 4), i * 3f);

            Platforms.transform.position = Pos2;

            Instantiate(Platforms);
        }

        Pos2 = new Vector2(randomX + Random.Range(-4, 4), level1 * 3f);

        PlatformToWin.transform.position = Pos2;

        Instantiate(PlatformToWin);
    }

    public void Restarted()
    {
        Startlevel();
    }
}
