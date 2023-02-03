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
    public float JumpSpeed = 1f;
    public Vector3 Gravity = new Vector3(0f, -0.5f, 0f);

    [Header("Input Parameters")]
    public float DoubleTapTime = 0.5f;

    private GGJ2023 _inputActions;
    private bool _isGrounded = false;
    private Dictionary<InputAction, float> _timesSinceLastPressed = new Dictionary<InputAction, float>(); 

    private void Awake()
    {
        _inputActions = new GGJ2023();
        _inputActions.Enable();

        _timesSinceLastPressed.Add(_inputActions.Player.Left, 0f);
        _timesSinceLastPressed.Add(_inputActions.Player.Right, 0f);
        _timesSinceLastPressed.Add(_inputActions.Player.Down, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // Check if character is grounded this frame
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, -Vector2.up * _collisionBox.size.y * 0.5f);
        _isGrounded = (groundHit.collider != null); // #TODO collision tags for platforms/players

        Vector2 _frameForce = new Vector2(0f, 0f);

        // Inputs
        HandleInputs(ref _frameForce);

        // transform.position += new Vector3(_frameForce.x, _frameForce.y, 0f) * Time.deltaTime;
        // transform.position += Gravity * Time.deltaTime;
        _rb.AddForce(_frameForce);

        // Update input time tracking dictionary
        _timesSinceLastPressed[_inputActions.Player.Left] += Time.deltaTime;    
        _timesSinceLastPressed[_inputActions.Player.Right] += Time.deltaTime;    
        _timesSinceLastPressed[_inputActions.Player.Down] += Time.deltaTime;    
    }

    // Check inputs for movement and double tap actions
    private void HandleInputs(ref Vector2 currentVelocity)
    {
        if (_inputActions.Player.Left.WasPerformedThisFrame())
        {
            if (_timesSinceLastPressed[_inputActions.Player.Left] < DoubleTapTime)
            {
                Debug.Log("Dodge Left"); // #TODO isDodging bool
            }

            _timesSinceLastPressed[_inputActions.Player.Left] = 0f;
        }

        if (_inputActions.Player.Left.IsPressed())
        {
            currentVelocity += new Vector2(-HorizontalSpeed, 0f);
        }

        if (_inputActions.Player.Right.WasPerformedThisFrame())
        {
            if (_timesSinceLastPressed[_inputActions.Player.Right] < DoubleTapTime)
            {
                Debug.Log("Dodge Right"); // #TODO isDodging bool
            }

            _timesSinceLastPressed[_inputActions.Player.Right] = 0f;
        }

        if (_inputActions.Player.Right.IsPressed())
        {
            currentVelocity += new Vector2(HorizontalSpeed, 0f);
        }

        if (_inputActions.Player.Up.IsPressed())
        {
            currentVelocity += new Vector2(0f, JumpSpeed);
        }

        if (_inputActions.Player.Down.WasPerformedThisFrame())
        {
            if (_timesSinceLastPressed[_inputActions.Player.Down] < DoubleTapTime && _isGrounded)
            {
                Debug.Log("Fall Through");
            }

            _timesSinceLastPressed[_inputActions.Player.Down] = 0f;
        }
    }
}
