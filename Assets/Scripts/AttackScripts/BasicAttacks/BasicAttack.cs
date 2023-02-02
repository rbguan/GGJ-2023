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
        if (other.gameObject.tag == "Opponet")
        {
            Debug.Log("Hit");
        }
    }
}
