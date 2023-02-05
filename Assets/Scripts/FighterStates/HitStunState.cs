using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStunState : FighterState
{
    [SerializeField]
    GameObject hitVFX;
    public override void OnStateEnter()
    {
        Debug.Log("HIT STUN TIMER");


        GetComponent<Animator>().SetBool("HitStunBool", true);
        Instantiate(hitVFX, transform.position, Quaternion.identity);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();

        GetComponent<Animator>().SetBool("HitStunBool", false);
    }

    public override void FighterStateUpdate(float axisValue)
    {
        base.FighterStateUpdate(axisValue);
    }
}
