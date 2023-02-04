using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDestroyScript : MonoBehaviour
{
    public SpecialAttack attachedSpecialAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetUp(SpecialAttack sp)
    {
        attachedSpecialAttack = sp;
        StartCoroutine(DestroyObj());
    }


    private IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(.8f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
