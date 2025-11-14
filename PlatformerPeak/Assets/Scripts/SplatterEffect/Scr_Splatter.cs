using UnityEngine;

public class Scr_Splatter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DestroySplatterObject", 5.0f);
    }


    private void DestroySplatterObject()
    {
        Destroy(gameObject);
    }
}
