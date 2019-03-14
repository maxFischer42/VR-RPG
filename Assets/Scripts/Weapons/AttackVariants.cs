using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVariants : MonoBehaviour
{
    public enum attackType { Normal, Slash, Pierce, Blunt};
    public float minimumVelocity;

    public void CheckAttackType(Collider _collider, Vector3 tipVelocity, Vector3 midVelocity, Vector3 gripVelocity)
    {
        //declare a basic attackType variable and set it's default to Normal
        attackType variant = attackType.Normal;
        bool isCritical = false;

        //sets variant to whatever the first collider is, and if the velocity is
        //high enough then the critical effect will apply
        switch(_collider.gameObject.GetComponent<HitTypeHolder>().myHitType.name)
        {
            case "Slash":
                variant = attackType.Slash;
                isCritical = CheckVelocity(variant, midVelocity);
                break;
            case "Piere":
                variant = attackType.Pierce;
                isCritical = CheckVelocity(variant, tipVelocity);
                break;
            case "Blunt":
                variant = attackType.Blunt;
                isCritical = CheckVelocity(variant, gripVelocity);
                break;
        }

        //if the velocity did not meet the requirement then it will
        //revert the attacktype back to normal
        if (!isCritical)
            variant = attackType.Normal;
        ApplyEffect(variant, tipVelocity, midVelocity, gripVelocity);
    }

    public void ApplyEffect(attackType _attackType, Vector3 tipVelocity, Vector3 midVelocity, Vector3 gripVelocity)
    {

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


}
