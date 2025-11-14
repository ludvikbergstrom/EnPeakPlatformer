using UnityEngine;

public class scr_ground_check : MonoBehaviour
{
    public bool isGrounded;

    public bool isGroundSlippery;

    private void Update()
    {
        isGroundSlippery = MapManager.Instance.GetTileSlipperines(transform.position - new Vector3(0f,0.2f,0f));
    }

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
            isGroundSlippery = false;
        }
    }
}
