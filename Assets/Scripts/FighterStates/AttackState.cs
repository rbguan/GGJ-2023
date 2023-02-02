using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : FighterState
{
    public bool attackCancellable = false;
    bool attackInterrupted = false;
    [SerializeField]
    BasicAttack fighterBasicAttack;
    PlayerAttack currentAttack;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        attackCancellable = false;
        attackInterrupted = false;
    }

    public override void FighterStateUpdate(float axisValue)
    {
        base.FighterStateUpdate(axisValue);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        
    }

    public void InterruptCurrentAttack(bool fromDamage)
    {
        currentAttack.InterruptAtack(fromDamage);
        attackInterrupted = true;
    }

    public void FinishAttack()
    {
        if(!attackInterrupted)
            coreObject.ChangeState(coreObject.attachedStates[FighterStates.Default]);
    }

    public override void BasicAttackInput()
    {
        if (coreObject.CurrentState == this)
        {
            currentAttack = fighterBasicAttack;
            fighterBasicAttack.PeformAttack();
        }
    }
}
