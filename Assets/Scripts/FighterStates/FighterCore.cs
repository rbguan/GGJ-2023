using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCore : MonoBehaviour
{
    
    private FighterState _currentState;//Starts as Default
    public FighterState CurrentState { get { return _currentState; } set { _currentState = value; } }
    
    [HideInInspector]//Dictionary that contains all attached componets that inherit from FighterState 
    public Dictionary<FighterStates, FighterState> attachedStates = new Dictionary<FighterStates, FighterState>();

    //FighterActions InputActions Map found in Assets/Input
    FighterActions fighterAction;
    
    //Horizontal movement value
    float axisValue;

    [HideInInspector]
    public bool _isGrounded = false;
    [SerializeField]
    public BoxCollider2D _collisionBox;
    public FighterActions GetInputActions()
    {
        return fighterAction;
    }

    private void Awake()
    {
        FighterState[] fighterStates = GetComponents<FighterState>();
        for (int i = 0; i < (int)FighterStates.Count; i++)
        {
            for(int y = 0; y < fighterStates.Length; y++)
            {
                if (fighterStates[y].GetFighterState() == (FighterStates)i)
                {
                    attachedStates.Add((FighterStates)i, fighterStates[y]);
                }
            }
            
        }

       
        fighterAction = new FighterActions();
        fighterAction.Enable();
        SetUpInput();

        ChangeState(attachedStates[FighterStates.Default]);
    }

    //Changes a state to a new one (Example: From AttackState to HitStun state)
    public void ChangeState(FighterState fighterState)
    {
        //Perform OnStateExit if the fighter is currently in a state
        if (CurrentState != null)
        {
            CurrentState.OnStateExit();
        }

        //Change state and perform onstateenter
        CurrentState = fighterState;
        CurrentState.OnStateEnter();

    }

    //Check if the Attack in AttackState is currently cancellable, and if it is and we are in AttackState, interrupt the attack
    public bool AttackStateCancellable()
    {
        if (CurrentState.GetFighterState() == FighterStates.Attack && (CurrentState as AttackState).attackCancellable)
        {
            Debug.Log("Attack Cancellable");
            (CurrentState as AttackState).InterruptCurrentAttack(false);
            return true;
        }
        else
            return false;
    }

    // Calls the current States's update method
    void Update()
    {
        ExecuteStateUpdate();
    }

    private void ExecuteStateUpdate()
    {
        if (CurrentState == null)
        {
            return;
        }

        attachedStates[CurrentState.GetFighterState()].FighterStateUpdate(axisValue);
    }

    private void SetUpInput()
    {
        fighterAction.Base.BasicAttack.performed += ctx =>
        {
            if (AttackStateCancellable() || CurrentState.GetFighterState() == FighterStates.Default)
            {
                ChangeState(attachedStates[FighterStates.Attack]);
                CurrentState.BasicAttackInput();
            }
        };
        fighterAction.Base.SpecialAttack.performed += ctx => 
        {
            if (AttackStateCancellable() || CurrentState.GetFighterState() == FighterStates.Default)
            {
                ChangeState(attachedStates[FighterStates.Attack]);
                CurrentState.SpecialAttackInput();
            }
        };
        fighterAction.Base.Jump.performed += ctx => 
        {
            if (AttackStateCancellable())
            {               
                ChangeState(attachedStates[FighterStates.Default]);
            }            
        };
        fighterAction.Base.Block.performed += ctx =>
        {
            if (AttackStateCancellable())
            {
                ChangeState(attachedStates[FighterStates.Default]);
            }
        };

        fighterAction.Base.FallThroughPlatform.performed += ctx =>
        {
            CurrentState.FallThroughPlatformInput();
        };

        fighterAction.Base.DodgeLeft.performed += ctx =>
        {
            CurrentState.DodgeInput(true);
        };

        fighterAction.Base.DodgeRight.performed += ctx =>
        {
            CurrentState.DodgeInput(false);
        };

        fighterAction.Base.Movement.performed += ctx =>
        {
            axisValue = ctx.ReadValue<float>();
        };
        fighterAction.Base.Movement.canceled += ctx =>
        {
            axisValue = ctx.ReadValue<float>();//should be 0
        };
    }
}
