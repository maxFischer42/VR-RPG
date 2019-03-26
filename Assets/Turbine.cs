using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : MonoBehaviour
{
    public Rotate[] turbineCogs;
    public GameObject[] inKeys;
    public AudioSource aud;
    public int keys = 3;


    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "TurbineKey" && keys > 0)
        {
            inKeys[keys - 1].SetActive(true);
            Destroy(collider.gameObject);
            keys--;
            if (keys == 0)
                ActivateRotation();
        }
    }

    void ActivateRotation()
    {
        aud.enabled = true;
        for(int i = 0; i < turbineCogs.Length - 1; i++)
        {
            turbineCogs[i].enabled = true;
        }
    }
}
