using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class PlayerAttack : MonoBehaviour
{

    public Animator playerAnimator;
    public int attackDamage;
    public BoxCollider2D hitBox;
    AttackState attachedAtackState;


    private void Awake()
    {
        attachedAtackState = GetComponent<AttackState>();
    }

    public virtual void PeformAttack()
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
        
        hitBox.enabled = false;

    }

    /***
    * Enables the hitbox for the defined attack, if it has one
    * hitBox is a triggerCollider attached to (1? the PlayerParent object or 2? a child attackObject)
    */
    public virtual void EnableHitBox()
    {
        hitBox.enabled = true;
    }

    public virtual void EndAttack()
    {
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
