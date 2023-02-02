using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public const string basicAnimationTrigger = "Basic";
    public const string specialAnimationTrigger = "Special";
    public const string hitStunTrigger = "HitStun";
    public const string cancelTrigger = "Cancel";
}


public enum FighterStates
{
    Default,
    Attack,
    HitStun,
    Count
}