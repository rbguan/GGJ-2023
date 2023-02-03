using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DefaultState : FighterState
{

    [SerializeField] Rigidbody2D _rb;

    [Header("Movement Parameters")]
    public float HorizontalSpeed = 1f; // units per second
    public float DodgeSpeed = 2f;
    public float JumpSpeed = 1f;
    public Vector3 Gravity = new Vector3(0f, -0.5f, 0f);


    InputAction jumpCTX;
    InputAction blockCTX;

    bool jumpActive = false;
    bool blockActive = false;
    // Update is called once per frame
    public override void FighterStateUpdate(float axisValue)
    {

        base.FighterStateUpdate(axisValue);

        if (jumpCTX != null)
        {
            if (jumpCTX.WasPerformedThisFrame())
                jumpActive = true;

            if (jumpActive && jumpCTX.IsPressed())
            {
                Debug.Log("JUMP BEING HELD");
            }
        }

        if (blockCTX != null)
        {
            if (blockActive && blockCTX.IsPressed())
            {
                Debug.Log("BLOCK BEING HELD");
            }

            if (blockCTX.WasPerformedThisFrame())
                blockActive = true;
        }
        Vector2 _frameForce = new Vector2(axisValue, 0f);

        HandleInputs(ref _frameForce);

       
        // transform.position += new Vector3(_frameForce.x, _frameForce.y, 0f) * Time.deltaTime;
        // transform.position += Gravity * Time.deltaTime;
        _rb.AddForce(_frameForce);


      

       
    }

    void HandleInputs(ref Vector2 currentVelocity)
    {
        currentVelocity += new Vector2(HorizontalSpeed * currentVelocity.x, 0f);
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
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        jumpActive = false;
        blockActive = false;
    }
}
