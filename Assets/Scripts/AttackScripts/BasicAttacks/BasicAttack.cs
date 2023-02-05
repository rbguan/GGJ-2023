using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : PlayerAttack
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void PeformAttack()
    {
        base.PeformAttack();

        base.TriggerAnimation(Settings.basicAnimationTrigger);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (base.attachedAtackState.GetCurrentAttack() == this && other.gameObject.tag == "Player")
        {
            if (!GetHasDealtDamage())
            {
                Debug.Log("Hit");
                Vector2 hitBoxPos = UtilityFunctionLibrary.GetVec3AsVec2(hitBox.transform.position);
                Vector2 collisonDirection = other.ClosestPoint(hitBoxPos) - hitBoxPos;
                OnHit(other.gameObject.GetComponent<FighterCore>(), collisonDirection);
                DamageDealt();
            }
        }
    }   
}
