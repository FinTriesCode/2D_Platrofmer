using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PointToPointEnemy : MonoBehaviour
{
    [SerializeField] 
    private float movementSpeed = 5f;
    [SerializeField]
    private GameObject startPos;
    [SerializeField]
    private GameObject endPos;

    private Transform currentPos;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
        
        currentPos = endPos.transform;
    }

    void Update()
    {
        EnemyPatrol(startPos, endPos);
    }

    private void EnemyPatrol(GameObject startPos, GameObject endPos)
    {
        var point = currentPos.transform.position - transform.position;

        rigidBody.velocity = currentPos == endPos.transform
            ? new Vector3(movementSpeed, 0, 0)
            : new Vector3(-movementSpeed, 0, 0);

        //switch direction
        SwitchMovementDirection();
    }

    private void SwitchMovementDirection()
    {
        if (Vector3.Distance(transform.position, currentPos.transform.position) < 0.5f && currentPos == endPos.transform)
        {
            currentPos = startPos.transform;
        }
        if (Vector3.Distance(transform.position, currentPos.transform.position) < 0.5f && currentPos == startPos.transform)
        {
            currentPos = endPos.transform;
        }
    }

    //conflicts with EnemyPatrol
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Hazard"))
    //     {
    //         rigidBody.velocity = new Vector3(movementSpeed *= -1, 0, 0); //switch direction
    //     }
    // }
}
