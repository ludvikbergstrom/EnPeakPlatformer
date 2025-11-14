using UnityEngine;
using UnityEngine.InputSystem;

public class scr_ChangePlayerPrefab : MonoBehaviour
{
    public GameObject p2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var InputManager = GameObject.FindWithTag("PlayerManager").GetComponent<PlayerInputManager>();
        InputManager.playerPrefab = p2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
