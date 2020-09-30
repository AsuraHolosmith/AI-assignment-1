// Daniel Carr
// 100660903
// Controls player movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb3d;
    public UISwitcher uiSwitcher;

    private void Start()
    {
        rb3d = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!uiSwitcher.GetMoveDisabled()) // this prevents the player from moving until the file path has been entered
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");   

            Vector3 movement = new Vector3(moveX, 0, moveZ);

            rb3d.AddForce(movement * speed);
        }
    }
}
