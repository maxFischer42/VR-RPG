using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Vector3 playerStart;

    // Start is called before the first frame update
    void Start()
    {
        playerStart = GameObject.Find("PlayerNull").transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("PlayerNull").transform.position = playerStart;
        }
    }
}
