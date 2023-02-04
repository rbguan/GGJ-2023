using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : PlayerAttack
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  

    public override void PeformAttack()
    {
        base.PeformAttack();

        base.TriggerAnimation(Settings.specialAnimationTrigger);

        StartSpecialAttack();
    }

    [SerializeField]
    FighterCore fighterCore;
    [SerializeField]
    GameObject graphics;
    

    float timeToWait = .4f;
    public override void StartSpecialAttack()
    {
        Debug.Log("SPECIAL ATTACK PERFORMED");
        Vector3 side;
        if (fighterCore.isLeft)
            side = -graphics.transform.right;
        else
            side = graphics.transform.right;

        float radius = spikePrefab.GetComponent<BoxCollider2D>().size.x / 2;
        Vector3 spawnPosition = graphics.transform.position;
        spawnPosition += side * (radius * 2);

        StartCoroutine(SpawnSpikePrefab(3, timeToWait, radius, spawnPosition, side));

    }

    public IEnumerator SpawnSpikePrefab(int iterations, float timeToWait, float radius, Vector3 spawnPos, Vector3 side)
    {
        yield return new WaitForSeconds(timeToWait);
        GameObject newPrefab = Instantiate(spikePrefab, spawnPos, Quaternion.identity);
        newPrefab.GetComponent<SpikeDestroyScript>().SetUp(this);
        if (fighterCore.GetPlayerNum() == 1)
            Debug.Log("CHANGE TO PLAYER 1 LAYER");//newPrefab.layer 
        else if (fighterCore.GetPlayerNum() == 2)
            Debug.Log("CHANGE TO PLAYER 2 LAYER");

        spawnPos += side * (radius * 2);
        iterations--;
        if (iterations > 0)
        {
            StartCoroutine(SpawnSpikePrefab(iterations, this.timeToWait, radius, spawnPos, side));
        }
        else
        {
            base.EndAttack();
        }
    }

    [SerializeField]
    GameObject spikePrefab;
    // Update is called once per frame
    void Update()
    {

    }
}
