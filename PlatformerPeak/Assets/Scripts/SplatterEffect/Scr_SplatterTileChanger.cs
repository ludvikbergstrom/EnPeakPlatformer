using UnityEngine;
using UnityEngine.Tilemaps;

public class Scr_SplatterTileChanger : MonoBehaviour
{
    private Tilemap map;

    [SerializeField]
    private TileBase grassTile;

    [SerializeField]
    private TileBase iceTile;

    public PlayerSmearScript smearScript;

    private void Start()
    {
        map = FindFirstObjectByType<Tilemap>();
    }
    private void Update()
    {
        if (smearScript.smearOn)
        {
            Vector3 offsetPos = transform.position - new Vector3(0f, 0.2f, 0f);
            Vector3Int cellPos = Vector3Int.FloorToInt(offsetPos);
            if (map.GetTile(cellPos) == grassTile)
                map.SetTile(cellPos, iceTile);
        }
    }
}
