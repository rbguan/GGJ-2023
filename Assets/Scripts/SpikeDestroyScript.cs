using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDestroyScript : MonoBehaviour
{
    public RootSpecial attachedSpecialAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetUp(RootSpecial sp)
    {
        attachedSpecialAttack = sp;
        StartCoroutine(DestroyObj());
    }


    private IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(.8f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!attachedSpecialAttack.GetHasDealtDamage())
            {
                Debug.Log("Hit");
                Vector2 hitBoxPos = UtilityFunctionLibrary.GetVec3AsVec2(transform.position);
                Vector2 collisonDirection = other.ClosestPoint(hitBoxPos) - hitBoxPos;
                if (attachedSpecialAttack.isLeft)
                    attachedSpecialAttack.OnHit(other.gameObject.GetComponent<FighterCore>(), transform.right);
                else
                    attachedSpecialAttack.OnHit(other.gameObject.GetComponent<FighterCore>(), -transform.right);
                attachedSpecialAttack.DamageDealt();
            }
        }
    }
}
