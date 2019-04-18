using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public bool noY;
    public Vector3 velocity;
    public Rigidbody rb;

    void Update()
    {
        //get input from oculus touch joysticks
        float x = Input.GetAxis("Oculus_GearVR_LThumbstickX");
        float y = Input.GetAxis("Oculus_GearVR_LThumbstickY");
        
        //set Vectors based off of touch input
        Vector3 _movHorizontal = transform.right * x;
        Vector3 _movVertical = transform.forward * y;

        //save the added and normalized vectors as the velocity
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;
        if(noY)
            _velocity = new Vector3(_velocity.x,0f,_velocity.z);
        velocity = _velocity;
    }

    private void FixedUpdate()
    {
        //if velocity isnt equal to zero move the player
        if (velocity != Vector3.zero)
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
