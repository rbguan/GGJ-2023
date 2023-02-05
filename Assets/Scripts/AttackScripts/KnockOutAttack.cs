using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockOutAttack : PlayerAttack
{
    public override void PeformAttack()
    {
        base.PeformAttack();

        base.TriggerAnimation(Settings.knockOutString);
        Debug.Log("KNOCKOUT ATTACK PERFORMED");
        
        //animationEvent for endAttack enableAttackInterrupt enableHitBox and knockPlayerBack     
    }


    public override void EnableHitBox()
    {
        if (attachedAtackState.GetCurrentAttack() == this)
        {
            base.EnableHitBox();

            MovementComponent movementComp = GetComponent<MovementComponent>();
            movementComp.ZeroVelocity(true, false);
           // movementComp.ApplyKnockback(SelfPushbackForce * -side, SelfPushbackTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (base.attachedAtackState.GetCurrentAttack() == this && other.gameObject.tag == "Player")
        {
            if (!GetHasDealtDamage())
            {
                //Vector2 hitBoxPos = UtilityFunctionLibrary.GetVec3AsVec2(hitBox.transform.position);              
                other.gameObject.GetComponent<FighterCore>().KnockOut();
                Debug.Log("kill");
                DamageDealt();
            }
        }
    }
}
