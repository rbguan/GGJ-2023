using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DazedState : FighterState
{
    [SerializeField]
    GameObject dazeVFX;
    GameObject currentDazeVFX;
    public override void FighterStateUpdate(float axisValue)
    {
        base.FighterStateUpdate(0f);
    }


    public override void OnStateEnter()
    {
        base.OnStateEnter();
        if (currentDazeVFX != null)
        {
            Destroy(currentDazeVFX);
        }

        currentDazeVFX = Instantiate(dazeVFX, transform.position, Quaternion.identity, transform);

        GetComponent<Animator>().SetBool("Dazed", true);
    }


    public override void OnStateExit()
    {
        base.OnStateExit();
        Destroy(currentDazeVFX);
        GetComponent<Animator>().SetBool("Dazed", false);
        coreObject.PostDazeReset();
    }
}
