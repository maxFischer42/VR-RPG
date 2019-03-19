using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPathfinder : MonoBehaviour
{
    [Tooltip("X should be the basic movement speed, while Y should be the speed when chasing the player")]
    public Vector2 speed = new Vector2(1.7f, 3f);
    public Collider[] waypoints;
    private Collider currentTarget;
    public GameObject playerObject;
    private NavMeshAgent agent;
    private MeshRenderer mrenderer;
    public AudioClip footstep1, footstep2;
    public AudioSource feetSource;

    //checks whether or not the player is in sight of the child object
    public bool playerTarget;

    //for debug purposes, these will be applied to the waypoints
    //to see what is being targeted
    private Material waypointNormalMat;
    private Material waypointTargetMat;
    //this will be applied whether or not the player is being targeted
    private Material defaultMat;
    private Material targetMat;

    private float timer;

    private void Awake()
    {
        currentTarget = waypoints[RandomizeTargets(waypoints.Length)];
        SetMaterials();
        agent = GetComponent<NavMeshAgent>();
        mrenderer = GetComponent<MeshRenderer>();
    }


    public void Update()
    {
        if (!playerTarget)
        {
            agent.speed = speed.x;
            agent.SetDestination(currentTarget.transform.position);
 //           mrenderer.material = defaultMat;
            SendMessage("ChangeState", "WALK");
            if (Mathf.Abs(agent.velocity.x) < 0.1f && Mathf.Abs(agent.velocity.z) < 0.1f)
                ChangeTarget();
        }
        else if(playerTarget)
        {
//            mrenderer.material = targetMat;
            agent.speed = speed.y;
            agent.SetDestination(playerObject.transform.position);
            SendMessage("ChangeState", "RUN");
        }
        else
        {
            Debug.LogError("Bool can not equal null");
        }
        timer += Time.deltaTime;
        if((playerTarget && timer > (speed.y / 12)|| !playerTarget && timer > (speed.x / 8)) && agent.enabled)
        {
            int r = Random.Range(0, 1);
            timer = 0f;
            if (r == 0)
                feetSource.PlayOneShot(footstep1);
            else
                feetSource.PlayOneShot(footstep2);
        }
    }

    public void ChangeTarget()
    {
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
//           waypoints[i].GetComponent<MeshRenderer>().material = waypointNormalMat;
        }
//        currentTarget.GetComponent<MeshRenderer>().material = waypointTargetMat;
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
