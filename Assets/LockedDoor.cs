using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : MonoBehaviour
{
    public int keysIn = 0;
    public GameObject[] keyObj;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "GuardKey")
        {
            Destroy(other.gameObject);
            keysIn += 1;
            keyObj[keysIn].SetActive(true);
            if(keysIn == 3)
            {
                SceneManager.LoadScene("Opening");
            }
        }
    }
}
