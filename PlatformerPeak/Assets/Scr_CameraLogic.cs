using UnityEngine;

public class Scr_CameraLogic : MonoBehaviour
{
    public Transform cameraTarget;

    private Vector2 cameraLerp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = cameraTarget.position + new Vector3(0,0,-10);
    }
}
