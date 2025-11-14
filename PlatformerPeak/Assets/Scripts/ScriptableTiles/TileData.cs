using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;

    public bool slippery;

    public bool bouncy;

    public TileType tileType = TileType.None;

    public enum TileType
    {
        None,
        Slime,
        Ice
    }
}
