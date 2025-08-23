using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PointToPointEnemy : MonoBehaviour
{
 
    //set variables for script.
    [SerializeField] 
    private float movementSpeed = 5f;
    
    [SerializeField]
    private GameObject startPos;
    
    [SerializeField]
    private GameObject endPos;

    private Transform currentPos;
    private Rigidbody2D rigidBody;
    
    //on start happens as soon as the game is run.
    void Start()
    {
        //fetch the rigidbody component from the game object that the script is attached to
        //and freeze the rotation - ensuring the enemy doesn't 'fall over'
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
        
        //set current position, used later in script.
        currentPos = endPos.transform;
    }

    //update is called every tick.
    void Update()
    {
        EnemyPatrol(startPos, endPos);
    }

    //this method 
    private void EnemyPatrol(GameObject startPos, GameObject endPos)
    {
        //this is a turnary statement. 
            //this is the same as: if currentPos == endPoint then velocity = movementSpeed. Else, velocity = -movementSpeed.
        rigidBody.velocity = currentPos == endPos.transform
            ? new Vector3(movementSpeed, 0, 0)
            : new Vector3(-movementSpeed, 0, 0);

        //switch direction
        SwitchMovementDirection();
    }

    private void SwitchMovementDirection()
    {
        //if the enemy is 0.5f from the end position, turn and move towards the start position.
        if (Vector3.Distance(transform.position, currentPos.transform.position) < 0.5f && currentPos == endPos.transform)
        {
            currentPos = startPos.transform;
        }
        
        //if the enemy is 0.5f from the start position, turn and move towards the end position
        if (Vector3.Distance(transform.position, currentPos.transform.position) < 0.5f && currentPos == startPos.transform)
        {
            currentPos = endPos.transform;
        }
    }

    //Gizmos are just used for UI. In this case, the Gizmos take for of two circles and a line.
    //this is seen in-engine and shows the route, start and end of the enemy's patrol pattern.
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(startPos.transform.position, .5f);
        Gizmos.DrawSphere(endPos.transform.position, .5f);
        Gizmos.DrawLine(startPos.transform.position, endPos.transform.position);
    }
}
