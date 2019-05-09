using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health = 50;
    public GameObject corpse;
    public bool medium = true;
    public bool easy = true;

    private void Start()
    {
        int diff = PlayerPrefs.GetInt("Diff");
        switch(diff)
        {
            case 0:
                if (!easy)
                    gameObject.SetActive(false);
                break;
            case 1:
                if (!medium)
                    gameObject.SetActive(false);
                break;
        }
    }

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
