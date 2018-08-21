using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In meters per second")][SerializeField] float controlSpeed = 10f;
    [Tooltip("In meters per second")] [SerializeField] float xRange = 5f;
    [Tooltip("In meters per second")] [SerializeField] float yRange = 5f;

    [Header("Screen-position based")]
    [SerializeField] float positionPitchFactor = -5f; //what you multiply position by to get pitch
    [SerializeField] float positionYawFactor = 1f;

    [Header("Control-throw based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;
    

    // Update is called once per frame
    void Update ()
    {
        if(isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }

    }
    void OnPlayerDeath() // called by string reference
    {
        isControlEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); //DO NOT SET localRotation.x directly, it is quaternion, NOT Euler. Use this pattern instead.

    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //how far is the gamepad stick thrown to one side (+) or the other side (-) (goes between 0 and 1)
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime; //how many meters to move in this frame
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset; //clamp x position
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset; //clamp y position
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); //don't change z position
    }
}
