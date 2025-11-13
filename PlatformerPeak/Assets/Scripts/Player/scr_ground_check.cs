using UnityEngine;

public class scr_ground_check : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Surface"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Surface"))
        {
            isGrounded = false;
        }
    }
}
