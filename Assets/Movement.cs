using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 3f;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical); // since its a 3d game we dont need the y plane we jist need the controller to go left right up down

            if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);

        }
    }
}
