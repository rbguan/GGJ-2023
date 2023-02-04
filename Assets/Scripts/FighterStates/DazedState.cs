using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DazedState : FighterState
{
    public override void FighterStateUpdate(float axisValue)
    {
        base.FighterStateUpdate(0f);
    }
}
