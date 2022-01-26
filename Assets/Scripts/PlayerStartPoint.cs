using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    public Vector2 startDirection;

    private PlayerController thePlayer;
    private CameraController theCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Sets player position to start point position
        thePlayer = FindObjectOfType<PlayerController>();
        thePlayer.transform.position = transform.position;
        thePlayer.lastMove = startDirection;

        //Sets camera position to start point position
        theCamera = FindObjectOfType<CameraController>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
