using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject closed;
    public GameObject open;
    public bool test;

    public void Update()
    {
        if(test)
        {
            test = false;
            OpenClose();
        }
    }

    public bool isOpen;

    public void OpenClose()
    {
        isOpen = !isOpen;
        switch(isOpen)
        {
            case false:
                closed.SetActive(true);
                open.SetActive(false);
                break;
            case true:
                closed.SetActive(false);
                open.SetActive(true);
                break;
        }
    }
}
