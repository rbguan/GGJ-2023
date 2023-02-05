using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDestroyScript : MonoBehaviour
{
    public PlayerAttack attachedSpecialAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetUp(PlayerAttack sp)
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
                attachedSpecialAttack.DamageDealt();
            }
        }
    }
}
