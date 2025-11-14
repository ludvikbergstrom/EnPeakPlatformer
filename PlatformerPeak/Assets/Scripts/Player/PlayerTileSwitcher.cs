using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTileSwitcher : MonoBehaviour
{
    public bool isSlime;

    public void ChangeTile(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            MapManager.Instance.SwitchTile(isSlime);
        }
    }
}
