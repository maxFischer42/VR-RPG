using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponHolder : MonoBehaviour
{
    public EnemyWeapon weapon;
    public AudioSource aud;
    public EnemyAnimator enAnim;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    
}
