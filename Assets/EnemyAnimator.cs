using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public enum EnemyState {Idle, Walk, Run, Attack};
    public EnemyState currentState = EnemyState.Idle;

    public Animator anim;
    public RuntimeAnimatorController Idle;
    public RuntimeAnimatorController Walk;
    public RuntimeAnimatorController Run;
    public RuntimeAnimatorController Attack;

    private void Update()
    {        
        switch(currentState)
        {
            case EnemyState.Idle:
                anim.runtimeAnimatorController = Idle;
                break;
            case EnemyState.Walk:
                anim.runtimeAnimatorController = Walk;
                break;
            case EnemyState.Run:
                anim.runtimeAnimatorController = Run;
                break;
            case EnemyState.Attack:
                anim.runtimeAnimatorController = Attack;
                break;
        }
    }
}
