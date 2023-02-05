using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStunState : FighterState
{
    public override void OnStateEnter()
    {
        GetComponent<Animator>().SetBool("HitStunBool", true);
    }


    public override void FighterStateUpdate(float axisValue)
    {
        base.FighterStateUpdate(axisValue);
    }
}
