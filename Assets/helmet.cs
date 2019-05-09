using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmet : MonoBehaviour
{
    public bool isOn = false;
    public bool alert = false;
    public timer counter;
    public AudioSource musicPlayer;
    public AudioClip encouter;
    public bool test;


    public void Update()
    {
        if(test)
        {
            test = false;
            StateChange("on");
        }
    }

    public void StateChange(string message)
    {
        switch (message)
        {
            case "on":
                isOn = true;
                counter.enabled = true;
                break;
            case "off":
                alert = true;
                isOn = false;
                musicPlayer.clip = encouter;
                musicPlayer.Play();
                break;
        }
    }

}
