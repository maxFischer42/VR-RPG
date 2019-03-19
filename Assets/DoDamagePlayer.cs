using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamagePlayer : MonoBehaviour
{

    public PlayerHealthManager healthManager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Has Occured : " + other.name);
        if (other.gameObject.tag == "EnemyWeapon")
        {
            Debug.Log("Enemy succesfully hit the player");
            healthManager.DoDamage(other.gameObject.GetComponent<EnemyWeaponHolder>().weapon.damage);
            other.gameObject.GetComponent<EnemyWeaponHolder>().aud.PlayOneShot(other.gameObject.GetComponent<EnemyWeaponHolder>().weapon.hitSound);
        }
    }


}
