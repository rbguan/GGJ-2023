using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : FighterState
{

    [SerializeField] Rigidbody2D _rb;

    [Header("Movement Parameters")]
    public float HorizontalSpeed = 1f; // units per second
    public float DodgeSpeed = 2f;
    public float JumpSpeed = 1f;
    public Vector3 Gravity = new Vector3(0f, -0.5f, 0f);

    bool jumpActive = false;
    bool blockActive = false;
    // Update is called once per frame
    public override void FighterStateUpdate(float axisValue)
    {
        base.FighterStateUpdate(axisValue);

        if (fighterActions.Base.Jump.WasPerformedThisFrame())
            jumpActive = true;

        if (fighterActions.Base.Block.WasPerformedThisFrame())
            blockActive = true;

        Vector2 _frameForce = new Vector2(axisValue, 0f);

        HandleInputs(ref _frameForce);

        if (jumpActive && fighterActions.Base.Jump.IsPressed())
        {
            Debug.Log("JUMP BEING HELD");
        }
        // transform.position += new Vector3(_frameForce.x, _frameForce.y, 0f) * Time.deltaTime;
        // transform.position += Gravity * Time.deltaTime;
        _rb.AddForce(_frameForce);


      

        if (blockActive && fighterActions.Base.Block.IsPressed())
        {
            Debug.Log("BLOCK BEING HELD");
        }
    }

    void HandleInputs(ref Vector2 currentVelocity)
    {
        currentVelocity += new Vector2(HorizontalSpeed * currentVelocity.x, 0f);
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
