// Daniel Carr
// 10066903
// Detects when the player is colliding with one of the doors, allowing the door to be interacted with

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingWithPlayer : MonoBehaviour
{
    public Door door;

    // detects when the player is colliding with a given door,
    // and enables the ability to interact with it
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            door.colliding = true;
        
    }

    // detects when the player stops colliding with a given door,
    // and disables the ability to interact with it
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            door.colliding = false;
    }
}
