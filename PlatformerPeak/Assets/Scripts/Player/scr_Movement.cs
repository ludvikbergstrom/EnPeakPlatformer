using UnityEngine;
using UnityEngine.InputSystem;

public class scr_Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 4.0f;
    public float slipperyMoveSpeed = 6.0f;
    public float groundLerp = 6.0f;
    public float slipperyLerp = 1.0f;

    [Header("Jump Settings")]
    public float jumpStrength = 5.0f;
    public float bouncyJumpMultiplier = 1.8f;

    [Header("Jump Buffer & Coyote Time")]
    public float jumpBufferTime = 0.3f;
    public float coyoteTime = 0.1f;

    private float jumpBufferCounter;
    private float coyoteCounter;

    [Header("Components")]
    public scr_ground_check Ground_Check;

    [Header("Slippery State Settings")]
    public float slipperyDecayTime = 0.3f;

    private bool slipperyActive = false;
    private float slipperyTimer = 0f;


    private Rigidbody2D rb;
    private Vector2 movementInputDirection;
    private Vector2 smoothInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleTimers();
        HandleMovement();
        HandleSlipperyState();
        HandleJump();
        HandleAutoBounce();
    }

    // ----------------------------------------------------------
    // INPUT
    // ----------------------------------------------------------

    public void MovementInput(InputAction.CallbackContext ctx)
    {
        var val = ctx.ReadValue<Vector2>();
        movementInputDirection = new Vector2(val.x, 0);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            jumpBufferCounter = jumpBufferTime;  // store jump intent
        }
    }

    // ----------------------------------------------------------
    // TIMERS (jump buffer + coyote time)
    // ----------------------------------------------------------

    void HandleTimers()
    {
        // Count down jump buffer
        jumpBufferCounter -= Time.deltaTime;

        // Refresh coyote when on ground
        if (Ground_Check.isGrounded)
            coyoteCounter = coyoteTime;
        else
            coyoteCounter -= Time.deltaTime;
    }

    // ----------------------------------------------------------
    // MOVEMENT
    // ----------------------------------------------------------

    void HandleMovement()
    {
        float currentLerp = slipperyActive ? slipperyLerp : groundLerp;
        float currentSpeed = slipperyActive ? slipperyMoveSpeed : moveSpeed;


        smoothInput = Vector2.Lerp(smoothInput, movementInputDirection, currentLerp * Time.deltaTime);

        rb.linearVelocity = new Vector2(currentSpeed * smoothInput.x, rb.linearVelocity.y);
    }

    // ----------------------------------------------------------
    // SLIPPERY STATE HANDLING
    // ----------------------------------------------------------

    void HandleSlipperyState()
    {
        if (Ground_Check.isGroundSlippery)
        {
            slipperyActive = true;
            slipperyTimer = slipperyDecayTime;
        }
        else if (!Ground_Check.isGroundSlippery && Ground_Check.isGrounded)
        {
            if (slipperyTimer > 0)
                slipperyTimer -= Time.deltaTime;
            else
                slipperyActive = false;
        }
    }

    // ----------------------------------------------------------
    // JUMPING (with buffer + coyote + bouncy multiplier)
    // ----------------------------------------------------------

    void HandleJump()
    {
        if (jumpBufferCounter > 0 && coyoteCounter > 0)
        {
            float finalJump = jumpStrength;

            if (Ground_Check.isGroundBouncy)
                finalJump *= bouncyJumpMultiplier;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, finalJump);

            jumpBufferCounter = 0; // consume buffered jump
        }
    }

    // ----------------------------------------------------------
    // AUTO-BOUNCE (bouncy surface)
    // ----------------------------------------------------------

    void HandleAutoBounce()
    {
        if (Ground_Check.isGroundBouncy && Ground_Check.isGrounded)
        {
            if (rb.linearVelocity.y <= 0.1f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 2f); // small bounce
            }
        }
    }
}
