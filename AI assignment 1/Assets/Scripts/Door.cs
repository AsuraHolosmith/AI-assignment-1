// Daniel Carr
// 100660903
// Contains all the variables needed for the doors, as well as triggers to activate fire, noise, and safe/unsafe door visuals

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public DoorBehaviour doorBehaviour;
    public bool isHot, isNoisy, isSafe;
    public int doorNumber;
    public PlayerController control;
    public bool colliding = false;
    private bool isFinished = false;

    public GameObject fireYes;
    public GameObject fireNo;
    public GameObject noisyYes;
    public GameObject noisyNo;
    public GameObject safeYes;
    public GameObject safeNo;

    private bool uiOneActive = false;
    private bool uiTwoActive = false;

    private void Update()
    {
        if (doorBehaviour.GetFinished() && !isFinished)
        {
            isHot = doorBehaviour.GetHot(doorNumber - 1);
            isNoisy = doorBehaviour.GetNoisy(doorNumber - 1);
            isSafe = doorBehaviour.GetSafe(doorNumber - 1);

            isFinished = true;
            //string log = "Door " + doorNumber + " is done";
            //Debug.Log(log);
        }

        // I probably should've put all this stuff into their own functions, but at this point I'm just going to leave it

        // this activates the correct UI elements for hot/noise when the player is touching the door
        if (colliding)
        {
            if (isHot)
                fireYes.SetActive(true);
            else
                fireNo.SetActive(true);
        
            if (isNoisy)
                noisyYes.SetActive(true);
            else
                noisyNo.SetActive(true);

            uiOneActive = true;
        }

        // this deactivates any activated UI elements when the player stops touching the door
        else
        {
            if (uiOneActive)
            {
                if (isHot)
                    fireYes.SetActive(false);
                else
                    fireNo.SetActive(false);

                if (isNoisy)
                    noisyYes.SetActive(false);
                else
                    noisyNo.SetActive(false);

                uiOneActive = false;
            }

            if (uiTwoActive)
            {
                if (isSafe)
                    safeYes.SetActive(false);
                else
                    safeNo.SetActive(false);

                uiTwoActive = false;
            }
        }

        // this triggers the corresponding safe UI element if the player
            // presses the interact key while touching the door
        if (Input.GetButtonDown("Interact") && colliding)
        {
            if (isSafe)
                SafeDoor();
            else
                UnsafeDoor();
        }
    }

    // these last two functions were from I was originally planning on doing actual graphics,
        // but when I decided to just go with UI elements I just left the triggers in their own functions

    // activates the safe door visual when triggered
    private void SafeDoor()
    {
        safeYes.SetActive(true);
        uiTwoActive = true;
        //Debug.Log("Good Door");
    }

    // activates the unsafe door visual when triggered
    private void UnsafeDoor()
    {
        safeNo.SetActive(true);
        uiTwoActive = true;
        //Debug.Log("Bad Door");
    }
}
