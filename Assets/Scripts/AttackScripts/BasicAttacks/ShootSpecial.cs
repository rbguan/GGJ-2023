using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpecial : PlayerAttack
{

    bool shouldBePulled = false;
    FighterCore theOpponent;
    Vector2 hitBoxStart;
    // Start is called before the first frame update

    public override void PeformAttack()
    {
        hitBoxStart = hitBox.offset;
        hitBox.offset = new Vector2(-99, -99);
        base.PeformAttack();
        theOpponent = null;
        base.TriggerAnimation(Settings.specialAnimationTrigger);
        Debug.Log("SPECIAL ATTACK PERFORMED");
        //animationEvent for endAttack enableAttackInterrupt enableHitBox and knockPlayerBack     
    }

    public override void EnableHitBox()
    {
        if (attachedAtackState.GetCurrentAttack() == this)
        {
            
            base.EnableHitBox();
            hitBox.offset = hitBoxStart;
            MovementComponent movementComp = GetComponent<MovementComponent>();
            movementComp.ZeroVelocity(true, false);
        }
    }

    public override void ShootSpecialPull()
    {
        base.ShootSpecialPull();
        if (theOpponent != null)
        {
            Vector2 direction = (this.transform.position - theOpponent.transform.position).normalized;
            theOpponent.ApplyAttackValues(attackDamage, ShieldDamage, KnockbackForce * direction, KnockbackTime);
            Debug.Log("Hit");
            DamageDealt();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (base.attachedAtackState.GetCurrentAttack() == this && other.gameObject.tag == "Player")
        {
            if (!GetHasDealtDamage())
            {
                shouldBePulled = true;
                theOpponent = other.gameObject.GetComponent<FighterCore>();
            }
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (base.attachedAtackState.GetCurrentAttack() == this && other.gameObject.tag == "Player")
        {
            if (!GetHasDealtDamage())
            {
                shouldBePulled = false;
                theOpponent = null;
                
            }
        }
    }

}
