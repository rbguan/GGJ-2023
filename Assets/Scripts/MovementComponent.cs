using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] Animator _animController;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] BoxCollider2D _collisionBox;

    [Header("Movement Parameters")]
    public float HorizontalSpeed = 1f; // units per second
    public float DodgeSpeed = 2f;
    public float DodgeTime = 0.5f;
    public float DodgeCooldown = 1.2f;
    public float JumpSpeed = 200f;
    public float JumpTime = 0.5f;
    public float FallThroughTime = 2f;
    public float MaxVelocity;
    // public Vector3 Gravity = new Vector3(0f, -0.5f, 0f);

    private FighterCore coreObject;

    public bool IsActionable { get; private set; } = true;
    public bool IsFallingThrough { get; private set; } = false;
    private bool _isDodging = false;
    private bool _canDodge = true;

    private void Awake()
    {
        coreObject = GetComponent<FighterCore>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb.inertia = 0f;
        _rb.drag = 0f;
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void ApplyHorizontalForce(float xAxisValue)
    {
        if (_isDodging)
        {
            return;
        }

        if (xAxisValue == 0f && coreObject.IsGrounded)
        {
            ZeroVelocity(true, false);
            return;
        }

        _rb.AddForce(new Vector2(HorizontalSpeed * xAxisValue, 0f));

        if (_rb.velocity.x > MaxVelocity)
        {
            _rb.velocity = new Vector3(MaxVelocity, _rb.velocity.y);
        }
    }

    [SerializeField]
    GameObject dashVFX;

    public void ApplyDodgeForce(float xAxisValue)
    {
        if (!_canDodge)
            return;
        _animController.SetTrigger(Settings.dodgeTrigger);
        Instantiate(dashVFX, transform.position, Quaternion.identity);
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(DodgeSpeed * xAxisValue, 0f));
        StartCoroutine(DodgeCooldownTimer());
    }

    public void ApplyVerticalForce()
    {
        ZeroVelocity(false, true);
        _rb.AddForce(new Vector2(0f, JumpSpeed));

        // Can remove gravity scale stuff if it feels too floaty
        StopCoroutine(DisableGravityForJump());
        _rb.gravityScale = 1f;

        StartCoroutine(DisableGravityForJump());
    }

    public void ApplyKnockback(Vector2 force, float time)
    {
        Debug.Log("FORCE" + force);
        _rb.AddForce(force);
        StartCoroutine(InactionableTimer(time));
    }

    public void ApplyForcedForce(Vector2 dir, float mag, float inactionableTime)
    {
        _rb.AddForce(dir * mag);

        if (inactionableTime > 0f)
        {
            StartCoroutine(InactionableTimer(inactionableTime));
        }
    }

    public void ApplyFallThrough()
    {
        StartCoroutine(ChangeFallThroughLayers());
    }

    public void ZeroVelocity(bool x, bool y)
    {
        if (x)
        {
            _rb.velocity = new Vector2(0f, _rb.velocity.y);
        }

        if (y)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        }
    }

    // inactionable timer
    private IEnumerator InactionableTimer(float time)
    {
        IsActionable = false;
        yield return new WaitForSeconds(time);
        IsActionable = true;
    }

    // fallthrough timer
    private IEnumerator ChangeFallThroughLayers()
    {
        coreObject.SwapPlayerLayer();
        IsFallingThrough = true;
        yield return new WaitForSeconds(FallThroughTime);
        IsFallingThrough = false;
        coreObject.SwapPlayerLayer();
    }

    // jump gravity scale timer
    private IEnumerator DisableGravityForJump()
    {
        _rb.gravityScale = 0f;
        yield return new WaitForSeconds(JumpTime);
        _rb.gravityScale = 1f;
    }

    // dodge cooldown
    private IEnumerator DodgeCooldownTimer()
    {
        _isDodging = true;
        _canDodge = false;
        yield return new WaitForSeconds(DodgeTime);
        _isDodging = false;
        if (coreObject.IsGrounded)
            ZeroVelocity(true, false);
        yield return new WaitForSeconds(DodgeCooldown - DodgeTime);
        _canDodge = true;
    }
}
