using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
public class KnockOutAttack : PlayerAttack
{
    [SerializeField]
    GameObject knockOutProjectile;

    public Transform spawnPoint;
    public override void PeformAttack()
    {
        base.PeformAttack();
        base.TriggerAnimation(Settings.knockOutString);
        Debug.Log("KNOCKOUT ATTACK PERFORMED");
        
        //animationEvent for endAttack enableAttackInterrupt enableHitBox and knockPlayerBack     
    }

    [SerializeField]
    GameObject graphics;
    Vector3 side;
    public override void EnableHitBox()
    {
        if (attachedAtackState.GetCurrentAttack() == this)
        {
            if (attachedFighterCore.isLeft)
                side = -graphics.transform.right;
            else
                side = graphics.transform.right;
            //base.EnableHitBox();
            GameObject newObj = Instantiate(knockOutProjectile, spawnPoint.position, Quaternion.identity);
            //newObj
            if (attachedFighterCore.GetPlayerNum() == 1)
                newObj.layer = LayerMask.NameToLayer("Player1");
            else if (attachedFighterCore.GetPlayerNum() == 2)
                newObj.layer = LayerMask.NameToLayer("Player2");

            newObj.GetComponent<KnockOutProjectileScript>().InitKillObj(side);

            MovementComponent movementComp = GetComponent<MovementComponent>();
            movementComp.ZeroVelocity(true, false);
           // movementComp.ApplyKnockback(SelfPushbackForce * -side, SelfPushbackTime);
        }
    }
}
