using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    //set variables and references.
    [SerializeField]
    private GameObject player;
    private Rigidbody2D playerRb;

    private void Start()
    {
        //find the player and fetch their rigidbody
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    //Gizmos are used to show these invisible objects in-engine as without these, they can be difficult to work with.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
}
