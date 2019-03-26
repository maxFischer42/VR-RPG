using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public Material setMat;
    public Vector3 addition;
    public GameObject particle;
    public float mult;

    private void Start()
    {
        if(setMat)
        {
            GetComponent<Renderer>().material = setMat;
        }
        if (particle)
        {
            particle.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(addition, Time.deltaTime * mult);
    }
}
