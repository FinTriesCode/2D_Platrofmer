using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    [Tooltip("The name of the scene which should be loaded upon collision with player.")]
    [SerializeField]
    private string sceneToLoad;
    //the above is a simple variable that is used to store the name of the desired scene to be loaded.

    //this is a collision check, in this case, it checks to see if the objective and the player touch.
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if this collision is found, the new scene is loaded.
        if (other.collider.CompareTag("Player"))
        { 
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log($"Scene: {sceneToLoad} was loaded. ");
        }
    }
}
