using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failsafe : MonoBehaviour
{

    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (rigidbody.velocity.y != 0f)
        {
        //    rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
        }
    }
}
