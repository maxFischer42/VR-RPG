using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetScript : MonoBehaviour
{
    public GameObject m_particleSystem;
    public GameObject spawnObject;
    public MeshRenderer m_renderer;
    public Collider m_collider;
    public bool notTarget;
    public bool test;
    public bool isSpike;
    public Rigidbody spikeRig;
    public bool isLoadGame;
    public int difficulty = 0;

    public EndGame endgame;
    public void Update()
    {
        if (test)
            RecieveArrow("HIT");
    }

    public void RecieveArrow(string message)
    {
        test = false;
        if(message == "HIT")
        {
            if(isLoadGame)
            {
                int m = 0;
                switch(difficulty)
                {
                    case 0:
                        m = 0;
                        break;
                    case 1:
                        m = 1;
                        break;
                    case 2:
                        m = 2;
                        break;
                }
                GameObject.Find("GameManager").SendMessage("SetDifficulty", m);
            }


            if(isSpike)
            {
                spikeRig.useGravity = true;
                StartCoroutine(endgame.winGame());
            }
            if (notTarget)
            {
                Destroy(m_renderer.gameObject);
            }
            else
            {
            spawnObject.SetActive(true);
                m_renderer.enabled = false;
                m_collider.enabled = false;
                m_particleSystem.SetActive(true);
            }
        }
    }




}
