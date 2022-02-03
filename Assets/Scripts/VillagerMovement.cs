using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool isWalking;
    public float walkTime;
    public float waitTime;

    private Rigidbody2D myRigidbody;
    private float walkCounter;
    private float waitCounter;
    private int WalkDirection;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch(WalkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);                    
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);                    
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);                    
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
