using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class FighterState : MonoBehaviour
{
    public FighterStates fighterState;
    protected FighterCore coreObject;
    protected MovementComponent movComp;
    private void Awake()
    {
        coreObject = GetComponent<FighterCore>();
        movComp = GetComponent<MovementComponent>();
    }

    private void Start()
    {
    }
    public virtual FighterStates GetFighterState()
    {
        return fighterState;
    }

    public virtual void BlockInput(InputAction blockCTX)
    {

    }

    public virtual void JumpInput(InputAction jumpCTX)
    {

    }
    public virtual void FallThroughPlatformInput()
    {

    }

    public virtual void DodgeInput(bool left)
    {

    }

    public virtual void MoveInput(float value)
    {

    }

    public virtual void SpecialAttackInput()
    {

    }

    public virtual void BasicAttackInput()
    {

    }

    //Override this method to assign EnemyState in EnemyCore as the override State, as well as do any other functionality that needs to occur on state enter
    public virtual void OnStateEnter()
    {

    }

    //override this method to perform any clean up functionality that needs to occur when this state ends
    public virtual void OnStateExit()
    {

    }

    //Override this method to call updates for this state: This occurs during FighterCore's update cycle;
    public virtual void FighterStateUpdate(float axisValue)
    {
        Vector2 basePoint = UtilityFunctionLibrary.GetVec3AsVec2(transform.position) + Vector2.down * coreObject._collisionBox.size.y * 0.5f;
        RaycastHit2D groundHit = Physics2D.Raycast(basePoint, Vector2.down, coreObject._collisionBox.size.y * 0.1f);
        coreObject.IsGrounded = (groundHit.collider != null)
            && !movComp.IsFallingThrough;

        if (axisValue < 0)
        {
            coreObject.FlipLeft();
        }
        else if (axisValue > 0)
        {
            coreObject.FlipRight();
        }
    }
}
