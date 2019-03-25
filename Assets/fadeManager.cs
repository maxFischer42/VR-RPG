using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeManager : MonoBehaviour
{
    public ObjectToFade[] ObjectsToFade = new ObjectToFade[1];
    public float timer;

    public void Update()
    {
        timer += Time.deltaTime;
        for (int i = 0; i < ObjectsToFade.Length; i++)
        {
            if (timer <= ObjectsToFade[i].length)
            {
                Color newOpacity = ObjectsToFade[i].textObj.color;
                newOpacity.a = ObjectsToFade[i].fadeCurve.Evaluate(timer / ObjectsToFade[i].length);
                ObjectsToFade[i].textObj.color = newOpacity;
            }
        }
    }
}


