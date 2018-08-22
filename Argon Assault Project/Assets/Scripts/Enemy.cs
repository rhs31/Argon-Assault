using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    ScoreBoard scoreBoard;
    bool hasBeenHit = false;

	// Use this for initialization
	void Start () {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    private void OnParticleCollision(GameObject other)
    {
        if(!hasBeenHit) // stops the game from doing two particle hits on the same enemy
        {
            hasBeenHit = true;
            scoreBoard.ScoreHit(scorePerHit);
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent; // set parent object
            Destroy(gameObject);
        }
        
    }
}
