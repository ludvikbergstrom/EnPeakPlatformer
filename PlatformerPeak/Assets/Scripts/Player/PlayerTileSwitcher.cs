using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTileSwitcher : MonoBehaviour
{
    public bool isSlime;
    public AudioClip switchSoundClip;
    [SerializeField] private float volume = 1.0f;

    public void ChangeTile(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            MapManager.Instance.SwitchTile(isSlime);
            SoundFXManager.Instance.PlaySoundFXClip(switchSoundClip, transform, volume);
        }
    }
}
