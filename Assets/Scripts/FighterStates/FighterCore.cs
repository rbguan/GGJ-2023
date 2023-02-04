using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
public class FighterCore : MonoBehaviour
{
    public InputUser user;

    private FighterState _currentState;//Starts as Default
    public FighterState CurrentState { get { return _currentState; } set { _currentState = value; } }
    
    [HideInInspector]//Dictionary that contains all attached componets that inherit from FighterState 
    public Dictionary<FighterStates, FighterState> attachedStates = new Dictionary<FighterStates, FighterState>();

    //FighterActions InputActions Map found in Assets/Input
    FighterActions fighterAction;
    [SerializeField]
    private int PlayerNum = 0;

    [SerializeField]
    GameObject playerGraphics;

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

    public void SetPlayerNum(int newNum)
    {
        PlayerNum = newNum;
        if (PlayerNum == 1)
            gameObject.layer = LayerMask.NameToLayer("Player1");
        else if (PlayerNum == 2)
            gameObject.layer = LayerMask.NameToLayer("Player2");
    }

    public int GetPlayerNum()
    {
        return PlayerNum;
    }


    Vector3 localScale;
    public bool isLeft = true;
    public void FlipRight()
    {
        if (isLeft)
        {
            localScale = playerGraphics.transform.localScale;
            localScale.x *= -1;
            playerGraphics.transform.localScale = localScale;
            isLeft = false;
        }
    }

    public void FlipLeft()
    {
        if (!isLeft)
        {
            localScale = playerGraphics.transform.localScale;
            localScale.x *= -1;
            playerGraphics.transform.localScale = localScale;
            isLeft = true;
        }
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

    private void OnDestroy()
    {
        user.UnpairDevices();
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

    public void BasicAttackInputEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum)
        {
            if (AttackStateCancellable() || CurrentState.GetFighterState() == FighterStates.Default)
            {
                ChangeState(attachedStates[FighterStates.Attack]);
                CurrentState.BasicAttackInput();
            }
        }
    }

    public void SpecialAttackInputEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum)
        {
            if (AttackStateCancellable() || CurrentState.GetFighterState() == FighterStates.Default)
            {
                ChangeState(attachedStates[FighterStates.Attack]);
                CurrentState.SpecialAttackInput();
            }
        }
    }

    public void FallThroughInputEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum)
        {
            CurrentState.FallThroughPlatformInput();
        }
    }

    public void DodgeLeftInputEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum)
        {
            CurrentState.DodgeInput(true);
        }
    }

    public void DodgeRightInputEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum)
        {
            CurrentState.DodgeInput(false);
        }
    }

    public void MovementEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum)
        {
            axisValue = ctx.ReadValue<float>();                          
        }
    }

    public void BlockEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum)
        {
            if (AttackStateCancellable() || CurrentState.GetFighterState() == FighterStates.Default)
            {                
                ChangeState(attachedStates[FighterStates.Default]);
                CurrentState.BlockInput(ctx.action);
            }
        }
    }

    public void JumpEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum)
        {
            if (AttackStateCancellable() || CurrentState.GetFighterState() == FighterStates.Default)
            {
                Debug.Log("jump");
                ChangeState(attachedStates[FighterStates.Default]);
                CurrentState.JumpInput(ctx.action);
            }
        }
    }

    private void OnEnable()
    {
        EventHandler.PlayerBasicAttackEvent += BasicAttackInputEvent;
        EventHandler.PlayerSpecialAttackEvent += SpecialAttackInputEvent;
        EventHandler.PlayerFallThroughEvent += FallThroughInputEvent;
        EventHandler.PlayerDodgeLeftEvent += DodgeLeftInputEvent;
        EventHandler.PlayerDodgeRightEvent += DodgeRightInputEvent;
        EventHandler.PlayerMovementEvent += MovementEvent;
        EventHandler.PlayerBlockEvent += BlockEvent;
        EventHandler.PlayerJumpEvent += JumpEvent;
    }

    private void OnDisable()
    {
        EventHandler.PlayerBasicAttackEvent -= BasicAttackInputEvent;
        EventHandler.PlayerSpecialAttackEvent -= SpecialAttackInputEvent;
        EventHandler.PlayerFallThroughEvent -= FallThroughInputEvent;
        EventHandler.PlayerDodgeLeftEvent -= DodgeLeftInputEvent;
        EventHandler.PlayerDodgeRightEvent -= DodgeRightInputEvent;
        EventHandler.PlayerMovementEvent -= MovementEvent;
        EventHandler.PlayerBlockEvent -= BlockEvent;
        EventHandler.PlayerJumpEvent -= JumpEvent;
    }

    
}
