using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPathfinder : MonoBehaviour
{
    public Collider[] waypoints;
    public Vector2 speed = new Vector2(1.7f, 3f);
    private Collider currentTarget;

    private NavMeshAgent agent;

    //for debug purposes, these will be applied to the waypoints
    //to see what is being targeted
    public Material waypointNormalMat;
    public Material waypointTargetMat;

    private void Awake()
    {
        currentTarget = waypoints[RandomizeTargets(waypoints.Length)];
        SetMaterials();
        agent = GetComponent<NavMeshAgent>();
    }


    public void Update()
    {
        agent.SetDestination(currentTarget.transform.position);
        if (Mathf.Abs(agent.velocity.x) < 0.1f && Mathf.Abs(agent.velocity.z) < 0.1f)
            ChangeTarget();
    }

    public void ChangeTarget()
    {
        agent.speed = speed.x;
        Collider[] newBatch = GetOtherWaypoints();
        currentTarget = newBatch[RandomizeTargets(newBatch.Length)];
        SetMaterials();
    }


    int RandomizeTargets(int length)
    {
        return Random.Range(0, length);
    }


    void SetMaterials()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i].GetComponent<MeshRenderer>().material = waypointNormalMat;
        }
        currentTarget.GetComponent<MeshRenderer>().material = waypointTargetMat;
    }


    //returns an array of colliders that will not contain the previous waypoint
    Collider[] GetOtherWaypoints()
    {
        List<Collider> colliderList = new List<Collider>();
        for(int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] != currentTarget)
            {
                colliderList.Add(waypoints[i]);
            }
        }
        return colliderList.ToArray();
    }

}
