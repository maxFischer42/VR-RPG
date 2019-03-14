using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayerController : MonoBehaviour
{

    public float speed = 1;
    public Rigidbody rigidbody;

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = (new Vector3(Input.GetAxis("Horizontal") * speed, 0f, Input.GetAxis("Vertical") * speed));
    }
}
