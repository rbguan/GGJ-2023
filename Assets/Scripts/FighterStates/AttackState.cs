using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : FighterState
{
    public bool attackCancellable = false;
    bool attackInterrupted = false;
    [SerializeField]
    BasicAttack fighterBasicAttack;
    [SerializeField]
    PlayerAttack fighterSpecialAttack;
    [SerializeField]
    PlayerAttack knockOutAttack;
    PlayerAttack currentAttack;
    [SerializeField]
    GameObject chargeVFX;
    GameObject currentChargeVFX;
    [SerializeField]
    Transform artPosition;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        attackCancellable = false;
        attackInterrupted = false;
    }

    public PlayerAttack GetCurrentAttack()
    {
        return currentAttack;
    }

    public override void FighterStateUpdate(float axisValue)
    {
        base.FighterStateUpdate(axisValue);
    }

    public override void OnStateExit()
    {
        if (currentChargeVFX != null)
        {
            Destroy(currentChargeVFX);
        }
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

    public override void SpecialAttackInput()
    {
        if (coreObject.CurrentState == this)
        {
            Debug.Log("SpecialAttack");
            currentAttack = fighterSpecialAttack;
            fighterSpecialAttack.PeformAttack();
        }
    }

    public override void KnockOutInput()
    {
        if (coreObject.CurrentState == this)
        {
            currentChargeVFX = Instantiate(chargeVFX, artPosition.position, Quaternion.identity, transform);
            Debug.Log("KnockOut");
            currentAttack = knockOutAttack;
            knockOutAttack.PeformAttack();
        }
    }

}
