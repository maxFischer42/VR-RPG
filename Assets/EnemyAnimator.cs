using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : MonoBehaviour
{
    public enum EnemyState {Idle, Walk, Run, Attack};
    public EnemyState currentState = EnemyState.Idle;

    public Animator anim;
    public RuntimeAnimatorController Idle;
    public RuntimeAnimatorController Walk;
    public RuntimeAnimatorController Run;
    public RuntimeAnimatorController Attack;
    public NavMeshAgent nav;

    private void Update()
    {

        if (!nav.enabled)
            currentState = EnemyState.Attack;
        switch(currentState)
        {
            case EnemyState.Idle:
                //anim.runtimeAnimatorController = Idle;
                anim.SetBool("Idle", true);
                break;
            case EnemyState.Walk:
                //anim.runtimeAnimatorController = Walk;
                anim.SetBool("Walk", true);
                break;
            case EnemyState.Run:
                //anim.runtimeAnimatorController = Run;
                anim.SetBool("Run", true);
                break;
            case EnemyState.Attack:
                //anim.runtimeAnimatorController = Attack;
                anim.SetBool("Attack", true);
                break;
        }
    }

    public void ChangeState(string state)
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);
        state = state.ToUpper();
        switch (state)
        {
            case "IDLE":
                currentState = EnemyState.Idle;
                break;
            case "WALK":
                currentState = EnemyState.Walk;
                break;
            case "RUN":
                currentState = EnemyState.Run;
                break;
            case "ATTACK":
                currentState = EnemyState.Attack;
                break;
        }
    }
}
