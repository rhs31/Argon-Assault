using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 3;

    ScoreBoard scoreBoard;

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
        ProcessHit();
        if (hits <= 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hits--;
        scoreBoard.ScoreHit(scorePerHit);
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent; // set parent object
        Destroy(gameObject);
    }
}
