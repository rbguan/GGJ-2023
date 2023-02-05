using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TootSpecial : PlayerAttack
{

    public override void PeformAttack()
    {
        base.PeformAttack();

        base.TriggerAnimation(Settings.specialAnimationTrigger);
        //animationEvent for endAttack enableAttackInterrupt enableHitBox and knockPlayerBack     
    }

    [SerializeField]
    GameObject graphics;

    public override void StartSpecialAttack()
    {
        Debug.Log("SPECIAL ATTACK PERFORMED");
        Vector3 side;
        if (attachedFighterCore.isLeft)
            side = -graphics.transform.right;
        else
            side = graphics.transform.right;

        //float radius = spikePrefab.GetComponent<BoxCollider2D>().size.x / 2;
        //Vector3 spawnPosition = graphics.transform.position;
        //spawnPosition += side * (radius * 2);    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (base.attachedAtackState.GetCurrentAttack() == this && other.gameObject.tag == "Player")
        {
            if (!GetHasDealtDamage())
            {
                Debug.Log("Hit");
                DamageDealt();
            }
        }
    }

    public void knockPlayerBack()
    {
        Debug.Log("SPECIAL ATTACK PERFORMED");
        Vector3 side;
        if (attachedFighterCore.isLeft)
            side = -graphics.transform.right;
        else
            side = graphics.transform.right;

        Vector3 spawnPosition = graphics.transform.position;
        //spawnPosition += side * (radius * 2);
    }
}
