using System.Collections.Generic;
using UnityEngine;

public class PlayerSmearScript : MonoBehaviour
{
    public GameObject smearPrefab; //poop smear
    public float smearRate = 0.1f;
    float nextSmear;
    Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody= GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ( nextSmear <= Time.time)
        {
            if (collision.gameObject.CompareTag("Surface"))
            {
                foreach (ContactPoint2D contact in collision.contacts)
                {
                    if (rigidBody.linearVelocity.magnitude > 0)
                    {
                        Instantiate(smearPrefab, contact.point, Quaternion.identity);
                        nextSmear = Time.time + smearRate;
                    }
                }
            }
        }

    }
}
