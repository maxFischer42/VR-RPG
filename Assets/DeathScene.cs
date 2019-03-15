using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OVR.OpenVR;

public class DeathScene : MonoBehaviour
{
    public string entryScene;

    public void Update()
    {        
        if(OVRInput.Get(OVRInput.Button.Start))
        {
            Application.Quit();
        }
    }

    public void Load(string condition)
    {
        SceneManager.LoadScene(entryScene);
    }
}
