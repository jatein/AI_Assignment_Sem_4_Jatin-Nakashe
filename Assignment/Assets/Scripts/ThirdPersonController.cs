using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float turnSmoothtime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // This will move the Player in horizontal/- direction with W/S and Up/Down keys 

        float vertical = Input.GetAxisRaw("Vertical"); // This will move the Player in vertical/- direction with A/D and Left/Right keys

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // this normalizes the speed of the player

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg; // for rotating the player 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothtime); // for making the rotation smooth
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            controller.Move(direction * speed * Time.deltaTime);
        }

    }
}
