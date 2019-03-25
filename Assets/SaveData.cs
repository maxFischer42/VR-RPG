using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SaveData : MonoBehaviour
{
    //0 = easy    1 = medium    2 = hard
    public int difficulty = 0;
    public int maxhp;
    public int currenthp;
    public float xsave;
    public float ysave;
    public float zsave;
    public string scene;

    public void SetDifficulty(string diff)
    {
        switch (diff)
        { 
        case "0":
            difficulty = 0;
            break;
        case "1":
            difficulty = 1;
            break;
        case "2":
            difficulty = 2;
            break;
        }
        GetComponent<SetDifficulty>().loadScene();
    }
}
