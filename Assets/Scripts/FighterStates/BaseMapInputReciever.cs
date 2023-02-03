using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseMapInputReciever : MonoBehaviour
{
    [SerializeField]
    MenuFighterActions menuActions;
    public void BasicAttackInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            EventHandler.CallPlayerBasicAttackEvent(menuActions.GetFighterNum(), ctx);
    }

    public void SpecialAttackInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            EventHandler.CallPlayerBasicAttackEvent(menuActions.GetFighterNum(), ctx);
    }

    public void DropDownInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            EventHandler.CallFallThroughEvent(menuActions.GetFighterNum(), ctx);
    }

    public void DodgeLeftInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            EventHandler.CallPlayerDodgeLeftEvent(menuActions.GetFighterNum(), ctx);
    }

    public void DodgeRightInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            EventHandler.CallPlayerDodgeRightEvent(menuActions.GetFighterNum(), ctx);
    }

    public void MovementInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed || ctx.canceled)
            EventHandler.CallPlayerMovementEvent(menuActions.GetFighterNum(), ctx);
    }

    public void BlockInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            EventHandler.CallPlayerBlockEvent(menuActions.GetFighterNum(), ctx);
    }

    public void JumpInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            EventHandler.CallPlayerJumpEvent(menuActions.GetFighterNum(), ctx);
    }

}

