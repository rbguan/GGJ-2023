using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSpecial : PlayerAttack
{
    public override void PeformAttack()
    {
        base.PeformAttack();

        base.TriggerAnimation(Settings.specialAnimationTrigger);

        StartSpecialAttack();
    }

    [SerializeField]
    GameObject graphics;

    public bool isLeft = false;

    float timeToWait = .4f;
    public override void StartSpecialAttack()
    {
        Debug.Log("SPECIAL ATTACK PERFORMED");
        Vector3 side;
        if (attachedFighterCore.isLeft)
        {
            side = -graphics.transform.right;
            isLeft = false;
        }
        else
        {
            side = graphics.transform.right;
            isLeft = true;
        }

        float radius = spikePrefab.GetComponent<BoxCollider2D>().size.x / 2;
        Vector3 spawnPosition = graphics.transform.position;
        spawnPosition += side * (radius * 2);

        StartCoroutine(SpawnSpikePrefab(3, timeToWait, radius, spawnPosition, side));

    }
    [SerializeField]
    LayerMask groundLayer;
    public IEnumerator SpawnSpikePrefab(int iterations, float timeToWait, float radius, Vector3 spawnPos, Vector3 side)
    {
        yield return new WaitForSeconds(timeToWait);

        RaycastHit2D hit = Physics2D.Raycast(spawnPos, Vector2.down, 6f, groundLayer);

        if (hit.collider != null)
        {
            spawnPos = hit.point;
            GameObject newPrefab = Instantiate(spikePrefab, spawnPos, Quaternion.identity);
            newPrefab.GetComponent<SpikeDestroyScript>().SetUp(this);
            if (attachedFighterCore.GetPlayerNum() == 1)
                newPrefab.layer = LayerMask.NameToLayer("Player1");
            else if (attachedFighterCore.GetPlayerNum() == 2)
                newPrefab.layer = LayerMask.NameToLayer("Player2");
        }
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
}
