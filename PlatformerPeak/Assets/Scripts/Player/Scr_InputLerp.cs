using UnityEngine;

public class Scr_InputLerp : MonoBehaviour
{
    public float MoveSpeed;
    private Vector2 Input;
    private Vector2 localInput;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        localInput = Vector2.Lerp(localInput,Input, MoveSpeed);
        rb.linearVelocity = localInput;
    }
}
