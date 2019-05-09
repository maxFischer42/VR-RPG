using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject explosion;
    public GameObject Dragon;

    public AudioClip boom;


    public IEnumerator winGame()
    {
        yield return new WaitForSeconds(2);
        explosion.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(boom);
        Destroy(Dragon);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Fries");
    }
}
