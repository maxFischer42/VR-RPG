using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVariants : MonoBehaviour
{
    public enum attackType { Normal, Slash, Pierce, Blunt};
    public float minimumVelocity;
    public int DMG;
    public Rigidbody tipBody;
    public Rigidbody mainBody;
    public Rigidbody hiltBody;
    private string currentHit;
    public AudioSource aud;
    public AudioClip normalHit;
    public AudioClip slashHit;
    public AudioClip pierceHit;
    public AudioClip bludgeHit;
    private AudioClip hitSound;

    public void CheckAttackType(Collider _collider, Vector3 tipVelocity, Vector3 midVelocity, Vector3 gripVelocity)
    {
        //declare a basic attackType variable and set it's default to Normal
        attackType variant = attackType.Normal;
        bool isCritical = false;
        hitSound = normalHit;
        //sets variant to whatever the first collider is, and if the velocity is
        //high enough then the critical effect will apply
        switch(_collider.gameObject.GetComponent<HitTypeHolder>().myHitType.name)
        {
            case "Slash":
                variant = attackType.Slash;
                isCritical = CheckVelocity(variant, midVelocity);
                hitSound = slashHit;
                break;
            case "Piere":
                variant = attackType.Pierce;
                isCritical = CheckVelocity(variant, tipVelocity);
                hitSound = pierceHit;
                break;
            case "Blunt":
                variant = attackType.Blunt;
                isCritical = CheckVelocity(variant, gripVelocity);
                hitSound = bludgeHit;
                break;
        }

        //if the velocity did not meet the requirement then it will
        //revert the attacktype back to normal
       /* if (!isCritical)
        {
            variant = attackType.Normal;
            hitSound = normalHit;
        }*/
        ApplyEffect(variant, tipVelocity, midVelocity, gripVelocity, _collider);
    }

    public void ApplyEffect(attackType _attackType, Vector3 tipVelocity, Vector3 midVelocity, Vector3 gripVelocity, Collider _collider)
    {
        int baseDMG = DMG;
        if(_attackType != attackType.Normal)
        {
            baseDMG += _collider.GetComponent<HitTypeHolder>().baseDmg;
        }
        GameObject.Find(currentHit).GetComponent<EnemyHealth>().health -= baseDMG;
        currentHit = "";
        aud.PlayOneShot(hitSound);
    }

    //returns whether or not the velocity checks out with the requirement
    //for the critical effect.
    public bool CheckVelocity(attackType _attackType, Vector3 _velocity)
    {
        bool _velocityCheck = false;
        if((_velocity.x > minimumVelocity && _velocity.y > minimumVelocity) || (_velocity.z > minimumVelocity && _velocity.y > minimumVelocity) ||
            (_velocity.x > minimumVelocity && _velocity.z > minimumVelocity) || (_velocity.x > minimumVelocity) || (_velocity.y > minimumVelocity)
            || (_velocity.z > minimumVelocity))
        {
            _velocityCheck = true;
        }
        return _velocityCheck;
    }

    public void Hit(Collider _collider,string _name)
    {
        Vector3 tipVel = tipBody.velocity;
        Vector3 midVel = mainBody.velocity;
        Vector3 hiltVel = hiltBody.velocity;
        currentHit = _name;
        CheckAttackType(_collider, tipVel, midVel, hiltVel);
    }
}
