using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DefaultState : FighterState
{
    InputAction jumpCTX;
    InputAction blockCTX;

    bool jumpActive = false;
    bool doubleJumpConsumed = false;
    bool blockActive = false;

    // Update is called once per frame
    public override void FighterStateUpdate(float axisValue)
    {
        base.FighterStateUpdate(axisValue);

        if (coreObject.IsGrounded)
        {
            doubleJumpConsumed = false;
        }

        if (jumpCTX != null)
        {
            if (jumpCTX.WasPerformedThisFrame())
            {
                if (coreObject.IsGrounded)
                {
                    movComp.ApplyVerticalForce();
                }
                else if (!doubleJumpConsumed)
                {
                    doubleJumpConsumed = true;
                    movComp.ApplyVerticalForce();
                }
            }

            if (jumpActive && jumpCTX.IsPressed())
            {
                Debug.Log("JUMP BEING HELD");//update logic for jump
            }
        }

        if (blockCTX != null)
        {
            if (blockActive && blockCTX.IsPressed())
            {
                Debug.Log("BLOCK BEING HELD");//update logic for block
            }

            if (blockCTX.WasPerformedThisFrame())
                blockActive = true;

            if (blockCTX.WasReleasedThisFrame())
                blockActive = false;
        }
        
        if (!blockActive)
            movComp.ApplyHorizontalForce(axisValue);
    }

    public override void BlockInput(InputAction blockCTX)
    {
        this.blockCTX = blockCTX;
    }

    public override void JumpInput(InputAction jumpCTX)
    {
        this.jumpCTX = jumpCTX;
    }
    public override void FallThroughPlatformInput()
    {
        base.FallThroughPlatformInput();
        if (blockActive)
            blockActive = false;

        movComp.ApplyFallThrough();
        Debug.Log("FallthroughPlatformPerformed");
    }

    public override void DodgeInput(bool left)
    {
        if (left)
        {
            Debug.Log("Dodge Left");
        }
        else
        {
            Debug.Log("Dodge Right");
        }

        float xAxisValue = left ? -1f : 1f;
        movComp.ApplyDodgeForce(xAxisValue);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        jumpActive = false;
        doubleJumpConsumed = false;
        blockActive = false;
    }
}
