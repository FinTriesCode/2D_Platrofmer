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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        { 
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log($"Scene: {sceneToLoad} was loaded. ");
        }
    }
}
