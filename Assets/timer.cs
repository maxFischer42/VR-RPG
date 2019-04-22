using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float length = 30;
    private float currentTime;
    public helmet m_helmet;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = length;   
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        string time = Mathf.Round(currentTime).ToString();
        GetComponent<Text>().text = time;
        if(currentTime <= 0)
        {
            m_helmet.SendMessage("StateChange", "off");
            GetComponent<Text>().text = "YOU HAVE BEEN DETECTED";
            GetComponent<Text>().color = Color.red;
            enabled = false;
        }
    }
}
