using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;
using OVR.OpenVR;
using UnityEngine.UI;

public class Crossbow : MonoBehaviour
{

    public bool isLoaded;

    [SerializeField]
    private string boltTag = "Bolt";

    public string handHeld;
    public Transform firePosition;
    public Transform fireTarget;
    public float boltSpeed = 1f;

    public GameObject firePrefab;
    public GameObject plasmaPrefab;
    public GameObject smokeEffect;
    public GameObject bolt1, bolt2, bolt3, bolt4;

    private OVRGrabbable grabbable;
    public AudioClip shootSound;
    public AudioClip hitSoundFire;

    private CrossbowBolt myBolt;
    private GameObject drop;
    //public GameObject hitEffect;

    public Text debugHand;

    public void Awake()
    { 
        grabbable = GetComponent<OVRGrabbable>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == boltTag && !isLoaded)
        {
            //destroy the bolt object in the world and
            //set the weapon to loaded
            myBolt = other.gameObject.GetComponent<BoltHolder>().myBolt;
            drop = myBolt.item;
            Destroy(other.gameObject);
            isLoaded = true;
            SetBolts(true);
        }
    }

    public void SetBolts(bool state)
    {
        bolt1.SetActive(state);
        bolt2.SetActive(state);
        bolt3.SetActive(state);
        bolt4.SetActive(state);
    }

    public void FixedUpdate()
    {
        //if the crossbow is loaded, check if
        //the trigger is being pressed 60 times a second
        if (isLoaded)
            FireBolt();
    }

    //recieves a message from the OVRGrabbable script
    //that will tell the crossbow what hand it is in
    public void CrossbowGrab(string _handName)
    {
        if(_handName.ToUpper().Contains("LEFT"))
        {
            handHeld = "L";
        }
        else if(_handName.ToUpper().Contains("RIGHT"))
        {
            handHeld = "R";
        }
        else
        {
            handHeld = "ERROR";
         //   Debug.LogError("The crossbow is being grabbed but no hand is recorded to hold the crossbow");
        }
        debugHand.text = handHeld;
    }



    public void FireBolt()
    {
        //check which hand the crossbow is in to determine
        //which trigger needs to be pressed on the Touch
        bool fireButton = false;
        if (OVRInput.Get(OVRInput.Button.Four) && handHeld == "L")
        {
            fireButton = true;
            debugHand.text = "FIRELEFTHAND";
        }
        else if (OVRInput.Get(OVRInput.Button.Two) && handHeld == "R")
        {
            fireButton = true;
            debugHand.text = "FIRERIGHTHAND";
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            fireButton = true;
            debugHand.text = "KEYBOARDOVERRIDE";
        }

        if (!fireButton)
            return;
        SetBolts(false);

               
        //creates a ray from the crossbow's end to where the bolt will hit.
        //gives the ray to a line renderer, and sets the line renderer's color
        //depending on what the bolt type is being used.
        //if the ray hits an object then it will create a particle and spawn
        //a new bolt in the scene.

        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(shootSound);
        RaycastHit hit;
        LineRenderer line = GetComponent<LineRenderer>();
        line.material = myBolt.trail;
        line.enabled = true;
        line.SetPosition(0, firePosition.position);
        Vector3 _direction = fireTarget.position - firePosition.position;
        Debug.Log(_direction);
        StartCoroutine(DelaySmoke());
        if(Physics.Raycast(firePosition.position,_direction,out hit, 99999f))
        {
            isLoaded = false;
            if(hit.collider)
            {
                hit.collider.SendMessage("RecieveArrow", "HIT");
                line.SetPosition(1, hit.point);
                Instantiate(drop, hit.point, transform.rotation);
                GameObject smokeObj = (GameObject)Instantiate(myBolt.hitPrefab, hit.point, Quaternion.identity);
                smokeObj.name = "BoomEffect";
                smokeObj.transform.parent = null;
                if(myBolt.boltType == CrossbowBolt.BoltType.Fire)
                {
                    smokeObj.GetComponent<AudioSource>().PlayOneShot(hitSoundFire);
                }
                Destroy(smokeObj, 3f);
                if(hit.collider.GetComponent<EnemyHealth>())
                {
                    hit.collider.GetComponent<EnemyHealth>().health -= drop.GetComponent<BoltHolder>().myBolt.damage;
                }
            }
        }
    }

    //disables the line renderer after 0.1 seconds
    public IEnumerator DelaySmoke()
    {
        yield return new WaitForSeconds(0.1f);
        LineRenderer line = GetComponent<LineRenderer>();
        line.enabled = false;
    }
}
