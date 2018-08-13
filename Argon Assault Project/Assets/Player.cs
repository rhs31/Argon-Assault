using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In meters per second")][SerializeField] float xSpeed = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //how far is the gamepad stick thrown to one side (+) or the other side (-) (goes between 0 and 1)
        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        print(xOffsetThisFrame);
	}
}
