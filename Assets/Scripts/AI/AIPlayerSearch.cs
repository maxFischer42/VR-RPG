using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerSearch : MonoBehaviour
{
    private AIPathfinder pathfinder;
    private GameObject player;
    public float maxDistance;
    public LayerMask layerMask;
    private LineRenderer line;
    public GameObject notice;

    private void Start()
    {
        pathfinder = gameObject.transform.parent.GetComponent<AIPathfinder>();
        player = GameObject.Find("PlayerNull");
        line = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        if(GameObject.Find("PlayerNull").GetComponent<helmet>())
        {
            if(GameObject.Find("PlayerNull").GetComponent<helmet>().alert)
            {
                RelayPlayer(true);
                notice.SetActive(true);
                return;
            }
        }
        RaycastHit hit;
        Vector3 direction = player.transform.position - transform.position;
        line.SetPosition(0, transform.position);
        if (Physics.Raycast(transform.position, direction, out hit, maxDistance, layerMask))
        {
            if(hit.collider)
            {               
                line.SetPosition(1, hit.point);
                if (hit.collider.gameObject.name == "PlayerNull")
                {
                    if (hit.collider.GetComponent<helmet>())
                    {
                        if (hit.collider.GetComponent<helmet>().isOn)
                        {
                            return;
                        }
                    }

                        RelayPlayer(true);
                    
                }
                else
                {
                    RelayPlayer(false);
                    
                }
            }
            else
                line.positionCount = 0;

        }
    }

    public void RelayPlayer(bool _bool)
    {
        pathfinder.playerTarget = _bool;
    }
}
