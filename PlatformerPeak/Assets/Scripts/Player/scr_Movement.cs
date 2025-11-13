using UnityEngine;
using UnityEngine.InputSystem;

public class scr_Movement : MonoBehaviour
{
    public float jumpStrength = 5.0f;
    public float moveSpeed = 4.0f;
    public scr_ground_check Ground_Check;


    private Rigidbody2D rb;
    private Vector2 movementInputDirection;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = movementInputDirection * moveSpeed + new Vector2(0, rb.linearVelocityY);
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && Ground_Check.isGrounded)
        {
            Debug.Log("jump");
            rb.linearVelocity = new Vector2(rb.linearVelocityX,jumpStrength);
        }
        else if (ctx.canceled)
        {
            Debug.Log("jumpn't");
        }
    }

    public void MovementInput(InputAction.CallbackContext ctx) 
    { 
        var value = ctx.ReadValue<Vector2>();
        movementInputDirection = new Vector2(value.x,0);
    }
}
