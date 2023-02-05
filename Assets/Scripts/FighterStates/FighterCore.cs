using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
public class FighterCore : MonoBehaviour
{
    public InputUser user;

    private MovementComponent movComp;

    private FighterState _currentState;//Starts as Default
    public FighterState CurrentState { get { return _currentState; } set { _currentState = value; } }
    
    //Dictionary that contains all attached componets that inherit from FighterState 
    [HideInInspector]
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
    public bool IsGrounded = false;
    [SerializeField]
    public BoxCollider2D _collisionBox;

    public int NumStocks = 3;
    public int MaxStamina;
    public int PostDazeStamina;
    public float MaxShield;
    public float DodgeTime;
    public float DazeTime;
    public float FastFallTime;
    private int _currentStamina;
    private float _currentShield;
    private bool _isBlocking;

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

    public void SwapPlayerLayer()
    {
        string newLayerName = "";

        switch (LayerMask.LayerToName(gameObject.layer))
        {
            case "Player1":
            {
                newLayerName = "Player1NoPlatform";
                break;
            }
            case "Player2":
            {
                newLayerName = "Player2NoPlatform";
                break;
            }
            case "Player1NoPlatform":
            {
                newLayerName = "Player1";
                break;
            }
            case "Player2NoPlatform":
            {
                newLayerName = "Player2";
                break;
            }
        }

        if (!newLayerName.Equals(""))
        {
            gameObject.layer = LayerMask.NameToLayer(newLayerName);
        }
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
        movComp = GetComponent<MovementComponent>();

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

    // Changes a state to a new one (Example: From AttackState to HitStun state)
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

    // Change state using enum
    public void ChangeState(FighterStates fighterStateEnum)
    {
        FighterState fighterState = attachedStates[fighterStateEnum];
        ChangeState(fighterState);
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
        if (playerNum == PlayerNum && movComp.IsActionable)
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
        if (playerNum == PlayerNum && movComp.IsActionable)
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
        if (playerNum == PlayerNum && movComp.IsActionable)
        {
            CurrentState.FallThroughPlatformInput();
        }
    }

    public void DodgeLeftInputEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum && movComp.IsActionable)
        {
            CurrentState.DodgeInput(true);
        }
    }

    public void DodgeRightInputEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum && movComp.IsActionable)
        {
            CurrentState.DodgeInput(false);
        }
    }

    public void MovementEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum && movComp.IsActionable)
        {
            axisValue = ctx.ReadValue<float>();                          
        }
    }

    public void BlockEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum && movComp.IsActionable)
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
        if (playerNum == PlayerNum && movComp.IsActionable)
        {
            if (AttackStateCancellable() || CurrentState.GetFighterState() == FighterStates.Default)
            {
                if (CurrentState.GetFighterState() != FighterStates.Default)
                {
                    ChangeState(attachedStates[FighterStates.Default]);
                }
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

    public void ApplyAttackValues(int staminaLoss, float shieldLoss, Vector2 knockbackVec, float knockbackTime)
    {
        if (_isBlocking)
        {
            _currentShield = Mathf.Clamp(_currentShield - shieldLoss, 0f, MaxShield);

            if(_currentShield == 0f)
            {
                // TODO what do when shield gon
            }
        }
        else if (CurrentState.fighterState == FighterStates.Dazed)
        {
            StopCoroutine(StartDaze());
            ChangeState(FighterStates.HitStun);
            movComp.ApplyKnockback(knockbackVec, knockbackTime);
        }
        else
        {
            _currentStamina = Mathf.Clamp(_currentStamina - staminaLoss, 0, MaxStamina);

            if (_currentStamina == 0f)
            {
                StartCoroutine(StartDaze());
            }
            else
            {
                ChangeState(FighterStates.HitStun);
            }

            movComp.ApplyKnockback(knockbackVec, knockbackTime);
        }
    }

    private IEnumerator StartDaze()
    {
        ChangeState(FighterStates.Dazed);
        yield return new WaitForSeconds(DazeTime);
        ChangeState(FighterStates.Default);
    }

    public void OnKill()
    {
        NumStocks--;
        if (NumStocks == 0)
        {
            // Game over
        }

        _currentStamina = MaxStamina;
    }
}
