using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rate;
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler( transform.rotation.eulerAngles + (direction * rate));   
    }
}
