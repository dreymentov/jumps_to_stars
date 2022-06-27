using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class gameManager1 : MonoBehaviour
{

    public GameObject Menu;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
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
}
