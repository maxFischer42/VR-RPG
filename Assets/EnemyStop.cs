using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStop : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<AIPathfinder>())
        {
            other.GetComponent<NavMeshAgent>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<AIPathfinder>())
        {
            other.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
