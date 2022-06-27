using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Movements : MonoBehaviour
{
    public float z = -10;
    public float minCameraX;
    public float maxCameraX;

    public GameObject cameraInPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(transform.position.x < minCameraX)
        {
            transform.position = new Vector3(minCameraX, transform.position.y, z);
        }
        else if (transform.position.x > maxCameraX)
        {
            transform.position = new Vector3(maxCameraX, transform.position.y, z);
        }*/
    }

    private void FixedUpdate()
    {
        //transform.position = new Vector3(cameraInPlayer.transform.position.x, transform.position.y, z);
    }
}
