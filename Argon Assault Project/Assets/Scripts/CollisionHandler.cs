using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        // send message is like delegate, it is a reflection system (see lec. 105) which sends message to all other components, triggering this method if they have it
        SendMessage("OnPlayerDeath"); 
    }
    private void ReloadScene() // string referenced
    {
        SceneManager.LoadScene(1);
    }
}
