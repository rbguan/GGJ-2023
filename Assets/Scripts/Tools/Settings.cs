using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public const string basicAnimationTrigger = "Basic";
    public const string specialAnimationTrigger = "Special";
    public const string hitStunTrigger = "HitStun";
    public const string cancelTrigger = "Cancel";
    public const string dodgeTrigger = "Dodge";
    public const string blockString = "Block";
    public const string dazeString = "Dazed";
    public const string knockOutString = "KnockOut";
}


public enum FighterStates
{
    Default,
    Attack,
    HitStun,
    Dazed,
    Count
}