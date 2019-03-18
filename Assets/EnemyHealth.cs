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
            collider.transform.parent.gameObject.GetComponent<AttackVariants>().Hit(collider,name);
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            GameObject m_corpse = (GameObject)Instantiate(corpse, transform);
            m_corpse.transform.parent = null;
            Destroy(gameObject);
        }
    }

}
