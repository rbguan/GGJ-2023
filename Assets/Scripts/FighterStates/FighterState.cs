using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterState : MonoBehaviour
{
    public FighterStates fighterState;
    protected FighterCore coreObject;
    protected FighterActions fighterActions;
    private void Awake()
    {
        coreObject = GetComponent<FighterCore>();
    }

    private void Start()
    {
        fighterActions = coreObject.GetInputActions();
    }
    public virtual FighterStates GetFighterState()
    {
        return fighterState;
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
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, -Vector2.up * coreObject._collisionBox.size.y * 0.5f);
        coreObject._isGrounded = (groundHit.collider != null); // #TODO collision tags for platforms/players
    }
}