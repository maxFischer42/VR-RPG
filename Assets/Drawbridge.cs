using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drawbridge : MonoBehaviour
{
    public bool test;

    public FixedJoint joint1;
    public FixedJoint joint2;

    private void Update()
    {
        if(test)
        {
            Destroy(gameObject.GetComponents<FixedJoint>()[0]);
            Destroy(gameObject.GetComponents<FixedJoint>()[1]);
        }
    }

    public GameObject block1;
    public GameObject block2;
    public string sceneToLoad;


    // Update is called once per frame
    void LateUpdate()
    {
        if (!block1 && !block2)
        {
            Destroy(joint1);
            Destroy(joint2);
            StartCoroutine(delay());
        }
    }

    public IEnumerator delay()
    {
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
