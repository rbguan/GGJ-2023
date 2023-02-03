using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public static class EventHandler
{
    public static event Action<int, InputAction.CallbackContext> PlayerBasicAttackEvent;

    //When a player char inventory is updated (Location of inventory (marth, convoy, draug, etc) and the list of items itself (Marth's falchion)
    public static void CallPlayerBasicAttackEvent(int player, InputAction.CallbackContext ctx)
    {
        if (PlayerBasicAttackEvent != null)
        {
            PlayerBasicAttackEvent(player, ctx);
        }
    }


    public static event Action<int, InputAction.CallbackContext> PlayerSpecialAttackEvent;

    //When a player char inventory is updated (Location of inventory (marth, convoy, draug, etc) and the list of items itself (Marth's falchion)
    public static void CallPlayerSpecialAttackEvent(int player, InputAction.CallbackContext ctx)
    {
        if (PlayerSpecialAttackEvent != null)
        {
            PlayerSpecialAttackEvent(player, ctx);
        }
    }

    public static event Action<int, InputAction.CallbackContext> PlayerFallThroughEvent;

    //When a player char inventory is updated (Location of inventory (marth, convoy, draug, etc) and the list of items itself (Marth's falchion)
    public static void CallFallThroughEvent(int player, InputAction.CallbackContext ctx)
    {
        if (PlayerFallThroughEvent != null)
        {
            PlayerFallThroughEvent(player, ctx);
        }
    }

    public static event Action<int, InputAction.CallbackContext> PlayerDodgeRightEvent;

    //When a player char inventory is updated (Location of inventory (marth, convoy, draug, etc) and the list of items itself (Marth's falchion)
    public static void CallPlayerDodgeRightEvent(int player, InputAction.CallbackContext ctx)
    {
        if (PlayerDodgeRightEvent != null)
        {
            PlayerDodgeRightEvent(player, ctx);
        }
    }

    public static event Action<int, InputAction.CallbackContext> PlayerDodgeLeftEvent;

    //When a player char inventory is updated (Location of inventory (marth, convoy, draug, etc) and the list of items itself (Marth's falchion)
    public static void CallPlayerDodgeLeftEvent(int player, InputAction.CallbackContext ctx)
    {
        if (PlayerDodgeLeftEvent != null)
        {
            PlayerDodgeLeftEvent(player, ctx);
        }
    }

    public static event Action<int, InputAction.CallbackContext> PlayerMovementEvent;

    //When a player char inventory is updated (Location of inventory (marth, convoy, draug, etc) and the list of items itself (Marth's falchion)
    public static void CallPlayerMovementEvent(int player, InputAction.CallbackContext ctx)
    {
        if (PlayerMovementEvent != null)
        {
            PlayerMovementEvent(player, ctx);
        }
    }

    public static event Action<int, InputAction.CallbackContext> PlayerJumpEvent;

    //When a player char inventory is updated (Location of inventory (marth, convoy, draug, etc) and the list of items itself (Marth's falchion)
    public static void CallPlayerJumpEvent(int player, InputAction.CallbackContext ctx)
    {
        if (PlayerJumpEvent != null)
        {
            PlayerJumpEvent(player, ctx);
        }
    }


    public static event Action<int, InputAction.CallbackContext> PlayerBlockEvent;

    //When a player char inventory is updated (Location of inventory (marth, convoy, draug, etc) and the list of items itself (Marth's falchion)
    public static void CallPlayerBlockEvent(int player, InputAction.CallbackContext ctx)
    {
        if (PlayerBlockEvent != null)
        {
            PlayerBlockEvent(player, ctx);
        }
    }



}
