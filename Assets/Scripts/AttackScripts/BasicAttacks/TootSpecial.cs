using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TootSpecial : PlayerAttack
{

    public override void PeformAttack()
    {
        base.PeformAttack();

        base.TriggerAnimation(Settings.specialAnimationTrigger);
        Debug.Log("SPECIAL ATTACK PERFORMED");
        if (attachedFighterCore.isLeft)
            side = -graphics.transform.right;
        else
            side = graphics.transform.right;
        //animationEvent for endAttack enableAttackInterrupt enableHitBox and knockPlayerBack     
    }

    [SerializeField]
    GameObject graphics;
    Vector3 side;
    public override void StartSpecialAttack()
    {


        //float radius = spikePrefab.GetComponent<BoxCollider2D>().size.x / 2;
        //Vector3 spawnPosition = graphics.transform.position;
        //spawnPosition += side * (radius * 2);    
    }

    public override void EnableHitBox()
    {
        if (attachedAtackState.GetCurrentAttack() == this)
        {
            base.EnableHitBox();
            GetComponent<MovementComponent>().ApplyKnockback(SelfPushbackForce * -side, SelfPushbackTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (base.attachedAtackState.GetCurrentAttack() == this && other.gameObject.tag == "Player")
        {
            if (!GetHasDealtDamage())
            {
                other.gameObject.GetComponent<FighterCore>().ApplyAttackValues(attackDamage, ShieldDamage, KnockbackForce * side, KnockbackTime);
                Debug.Log("Hit");
                DamageDealt();
            }
        }
    }
}
