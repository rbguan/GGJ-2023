using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class PlayerAttack : MonoBehaviour
{

    public Animator playerAnimator;    
    public BoxCollider2D hitBox;
    bool hasDealtDamage;
    protected AttackState attachedAtackState;
    protected FighterCore attachedFighterCore;

    [Header("Attack Params")]
    public int attackDamage;
    public float ShieldDamage;
    public float KnockbackForce;
    public float KnockbackTime;
    public float SelfPushbackForce = 0f;
    public float SelfPushbackTime = 0f;

    private void Awake()
    {
        attachedAtackState = GetComponent<AttackState>();
        attachedFighterCore = GetComponent<FighterCore>();
    }

    public void DamageDealt()
    {
        hasDealtDamage = true;
    }

    public bool GetHasDealtDamage()
    {
        return hasDealtDamage;
    }

    public virtual void PeformAttack()
    {
        hasDealtDamage = false;
    }

    public virtual void StartSpecialAttack()
    {

    }


    public virtual void EnableInputInterrupts()
    {
        attachedAtackState.attackCancellable = true;
    }

    /***
   * Inturrpets the Attack being preformed by either taking damage or from playerInput
   * @param damageTaken is a bool to say whether the atack should enter hitStun or normal movement
   */
    public virtual void InterruptAtack(bool damageTaken)
    {
        if (damageTaken)
        {
            playerAnimator.SetTrigger(Settings.hitStunTrigger);
        }
        else
        {
            playerAnimator.SetTrigger(Settings.cancelTrigger);
        }

        if (hitBox != null)
            hitBox.enabled = false;

    }

    /***
    * Enables the hitbox for the defined attack, if it has one
    * hitBox is a triggerCollider attached to (1? the PlayerParent object or 2? a child attackObject)
    */
    public virtual void EnableHitBox()
    {
        if (hitBox != null)
            hitBox.enabled = true;
    }

    public virtual void OnHit(FighterCore opponent, Vector2 collisionVec)
    {
        opponent.ApplyAttackValues(attackDamage, ShieldDamage, KnockbackForce * collisionVec, KnockbackTime);

        //Apply self pushback if not 0
        if (SelfPushbackForce > 0)
        {
            GetComponent<MovementComponent>().ApplyKnockback(SelfPushbackForce * -collisionVec, SelfPushbackTime);
        }
    }
    
    public virtual void EndAttack()
    {
        if (hitBox != null)
            hitBox.enabled = false;
        attachedAtackState.FinishAttack();
    }

    /***
     * Triggers the animation for the attached attack
     * @param trigger is the name of the trigger that the animatior needs to make the transition
     */
    public virtual void TriggerAnimation(string trigger)
    {
        playerAnimator.SetTrigger(trigger);
    }

}
