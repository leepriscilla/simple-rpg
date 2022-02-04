using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool isWalking;
    public float walkTime;
    public float waitTime;
    public Collider2D walkZone;
    public bool canMove;

    private Rigidbody2D myRigidbody;
    private float walkCounter;
    private float waitCounter;
    private int WalkDirection;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool hasWalkZone;
    private DialogueManager dMan;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        dMan = FindObjectOfType<DialogueManager>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        //if there is something in walkZone
        if(walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min; //bottom left
            maxWalkPoint = walkZone.bounds.max; //bottom right
            hasWalkZone = true;
        }

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {   
        if(!dMan.dialogActive)
        {
            canMove = true;
        }

        if(!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        if(isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch(WalkDirection)
            {
                case 0: //up
                    myRigidbody.velocity = new Vector2(0, moveSpeed); 
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1: //right
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    if(hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }                    
                    break;
                case 2: //down
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    if(hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }                    
                    break;
                case 3: //left
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    if(hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }                    
                    break;
            }
            
            if(walkCounter <= 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if(waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4); //0-3
        isWalking = true;
        walkCounter = walkTime;
    }
}
