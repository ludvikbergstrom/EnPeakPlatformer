using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


public class Scr_SplatterTileChanger : MonoBehaviour
{
    private Tilemap map;

    [SerializeField]
    private List<TileBase> tilesToChange;

    [SerializeField]
    private TileBase newTile;

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
            Vector3Int cellPos = map.WorldToCell(offsetPos);
            if (tilesToChange.Contains(map.GetTile(cellPos)))
                map.SetTile(cellPos, newTile);
        }
    }
}
