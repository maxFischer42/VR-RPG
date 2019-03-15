using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health = 50;
    public GameObject corpse;

    void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            collider.gameObject.GetComponent<AttackVariants>().Hit();
        }
    }

}
