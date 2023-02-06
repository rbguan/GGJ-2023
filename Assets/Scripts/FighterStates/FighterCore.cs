using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;
public class FighterCore : MonoBehaviour
{

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

    [Header("Audio Assets")]
    public AudioSource AudioSrc;
    public AudioClip AerialAttackSfx;
    public AudioClip BasicAttackSfx;
    public AudioClip CombatSfx1;
    public AudioClip CombatSfx2;
    public AudioClip DodgeSfx;
    public AudioClip JumpSfx1;
    public AudioClip JumpSfx2;
    public AudioClip KOAttackSfx1;
    public AudioClip KOAttackSfx2;
    public AudioClip RespawnSfx1;
    public AudioClip RespawnSfx2;
    public AudioClip SpecialClipSfx1;
    public AudioClip SpecialClipSfx2;
    public AudioClip StartSfx1;
    public AudioClip StartSfx2;

    [Header("Vital Params")]
    public int NumStocks = 3;
    public int MaxStamina;
    public int PostDazeStamina;
    public float MaxShield;
    public float ShieldDecayRate;
    public float ShieldRechargeRate;
    public float DazeTime;
    private int _currentStamina;
    private float _currentShield;

    [HideInInspector] public bool IsBlocking = false;

    List<Image> stock = new List<Image>();
    Slider playerStaminaSlider;

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

    public void SetPlayerStockBar(List<Image> stockBar)
    {
        foreach (Image stockItem in stockBar)
        {
            stock.Add(stockItem);
        }
    }

    public void SetPlayerHealthBar(Slider slider)
    {
        playerStaminaSlider = slider;
        playerStaminaSlider.maxValue = MaxStamina;
        playerStaminaSlider.minValue = 0;
        playerStaminaSlider.value = MaxStamina;
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

        _currentStamina = MaxStamina;
        _currentShield = MaxShield;

        // Start audio
        AudioClip startClip = Random.value > 0.5 ? StartSfx1 : StartSfx2;
        AudioSrc.PlayOneShot(startClip);
    }

    // Changes a state to a new one (Example: From AttackState to HitStun state)
    public void ChangeState(FighterState fighterState)
    {
        if (isDazed)
        {
            isDazed = false;
        }
        //Perform OnStateExit if the fighter is currently in a state
        if (CurrentState != null)
        {
            CurrentState.OnStateExit();
        }

        //Change state and perform onstateenter
        CurrentState = fighterState;
        CurrentState.OnStateEnter();

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

    [SerializeField]
    public Animator attachedAnimator;
    // Calls the current States's update method
    void Update()
    {
        ExecuteStateUpdate();
        attachedAnimator.SetFloat("yVelocity", GetComponent<Rigidbody2D>().velocity.y);
        UpdateBlock();
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

                if (AudioSrc.isPlaying) AudioSrc.Stop();
                AudioClip basicClip = IsGrounded ? BasicAttackSfx : AerialAttackSfx;
                AudioSrc.PlayOneShot(basicClip);
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

                if (AudioSrc.isPlaying) AudioSrc.Stop();
                AudioClip specialClip = UtilityFunctionLibrary.RandomBool() ? SpecialClipSfx1 : SpecialClipSfx2;
                AudioSrc.PlayOneShot(specialClip);
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
            if (AudioSrc.isPlaying) AudioSrc.Stop();
            AudioSrc.PlayOneShot(DodgeSfx);
        }
    }

    public void DodgeRightInputEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum && movComp.IsActionable)
        {
            CurrentState.DodgeInput(false);
            if (AudioSrc.isPlaying) AudioSrc.Stop();
            AudioSrc.PlayOneShot(DodgeSfx);
        }
    }

    public void MovementEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum && movComp.IsActionable)
        {
            axisValue = ctx.ReadValue<float>();
            attachedAnimator.SetFloat("xVelocity", axisValue);
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

                if (AudioSrc.isPlaying) AudioSrc.Stop();
                AudioClip jumpClip = UtilityFunctionLibrary.RandomBool() ? JumpSfx1 : JumpSfx2;
                AudioSrc.PlayOneShot(jumpClip);
            }
        }
    }


    public void KnockOutInputEvent(int playerNum, InputAction.CallbackContext ctx)
    {
        if (playerNum == PlayerNum && movComp.IsActionable)
        {
            if (AttackStateCancellable() || CurrentState.GetFighterState() == FighterStates.Default)
            {
                ChangeState(attachedStates[FighterStates.Attack]);
                CurrentState.KnockOutInput();

                if (AudioSrc.isPlaying) AudioSrc.Stop();
                AudioClip koClip = UtilityFunctionLibrary.RandomBool() ? KOAttackSfx1 : KOAttackSfx2;
                AudioSrc.PlayOneShot(koClip);
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
        EventHandler.PlayerKnockOutEvent += KnockOutInputEvent;
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
        EventHandler.PlayerKnockOutEvent -= KnockOutInputEvent;
    }

    public void ApplyAttackValues(int staminaLoss, float shieldLoss, Vector2 knockbackVec, float knockbackTime)
    {
        if (isDazed)
            return;

        if (IsBlocking)
        {
            BlockVfx.SetActive(true);
            _currentShield = Mathf.Clamp(_currentShield - shieldLoss, 0f, MaxShield);
            float percentage = _currentShield / MaxShield;
            BlockVfx.transform.localScale = (Vector3.one * shieldCurve.Evaluate(percentage));

            if (_currentShield == 0f)
            {
                BlockVfx.SetActive(false);
                StartCoroutine(StartDaze());
            }
        }
        else if (CurrentState.fighterState == FighterStates.Dazed)
        {
            ChangeState(FighterStates.Default);
            StopCoroutine(StartDaze());
            StartCoroutine(HitstunTimer(knockbackTime));
            movComp.ApplyKnockback(knockbackVec, knockbackTime);
        }
        else
        {
            if (CurrentState.fighterState == FighterStates.Attack)
                GetComponent<AttackState>().GetCurrentAttack().InterruptAtack(true);

            _currentStamina = Mathf.Clamp(_currentStamina - staminaLoss, 0, MaxStamina);
            playerStaminaSlider.value = _currentStamina;

            if (_currentStamina == 0f)
            {
                StartCoroutine(StartDaze());
            }
            else
            {
                StartCoroutine(HitstunTimer(knockbackTime));
            }

            movComp.ApplyKnockback(knockbackVec, knockbackTime);
        }
    }
    bool isDazed = false;
    
    private IEnumerator StartDaze()
    {
        
        FindObjectOfType<FightStageManager>().ScreenShakeSmall();
        ChangeState(FighterStates.Dazed);
        isDazed = true;
        yield return new WaitForSeconds(DazeTime);
        ChangeState(FighterStates.Default);
    }

    private IEnumerator HitstunTimer(float hitstuntime)
    {

        FindObjectOfType<FightStageManager>().ScreenShakeSmall();
        Debug.Log("HIT STUN TIMER");
        ChangeState(FighterStates.HitStun);
        yield return new WaitForSeconds(hitstuntime);
        ChangeState(FighterStates.Default);
    }    


    public void KnockOut()
    {

        OnKill();
        FightStageManager.Instance.ResetPositionToSpawnPoint(this);
    }

    public void OnKill()
    {
        NumStocks--;
        Image stockToDestory = stock[0];
        stock.RemoveAt(0);
        stockToDestory.enabled = false;

        if (NumStocks == 0)
        {
            FindObjectOfType<FightStageManager>().GoToVictoryScreen(this);
            // Game over
        }

        _currentStamina = MaxStamina;
        playerStaminaSlider.value = _currentStamina;
        _currentShield = MaxShield;
        float percentage = _currentShield / MaxShield;
        BlockVfx.transform.localScale = (Vector3.one * shieldCurve.Evaluate(percentage));

        // Respawn audio
        AudioClip respawnClip = UtilityFunctionLibrary.RandomBool() ? RespawnSfx1 : RespawnSfx2;
        AudioSrc.PlayOneShot(respawnClip);
    }

    [SerializeField]
    GameObject BlockVfx;
    [SerializeField]
    AnimationCurve shieldCurve;
    public void UpdateBlock()
    {
        if (IsBlocking)
        {
            _currentShield = Mathf.Clamp((_currentShield - ShieldDecayRate * Time.deltaTime), 0f, MaxShield);
            float percentage = _currentShield / MaxShield;
            BlockVfx.SetActive(true);
            BlockVfx.transform.localScale = ((Vector3.one * 2) * shieldCurve.Evaluate(percentage));
            Debug.Log(percentage + " ujwghuvbwduivbd " + ((Vector3.one * 2) * shieldCurve.Evaluate(percentage)));
            if (_currentShield == 0f)
            {
                StartCoroutine(StartDaze());
            }
        }
        else 
        {
            BlockVfx.SetActive(false);
            _currentShield = Mathf.Clamp(_currentShield + ShieldRechargeRate * Time.deltaTime, 0f, MaxShield);            
        }
    }

    public void PostDazeReset()
    {
        _currentStamina = PostDazeStamina;
        playerStaminaSlider.value = _currentStamina;
        _currentShield = MaxShield;
    }
}
