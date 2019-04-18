using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject m_particleSystem;
    public GameObject spawnObject;
    public MeshRenderer m_renderer;
    public Collider m_collider;

    public void RecieveArrow(string message)
    {
        if(message == "HIT")
        {
            m_renderer.enabled = false;
            m_collider.enabled = false;
            m_particleSystem.SetActive(true);
            spawnObject.SetActive(true);
        }
    }
}
