using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using static UnityEngine.Rendering.DebugUI;
public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }

    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private InputAction click;

    private void Awake()
    {
        // If Instance is null, this becomes the singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Optional: persist between scenes
        }
        else if (Instance != this)
        {
            Destroy(gameObject);  // Destroy duplicates
        }


        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }

    }


    private void Start()
    {
        click = InputSystem.actions.FindAction("attack");
    }

    private void Update()
    {
        if (click.IsPressed())
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);

            bool slippery = dataFromTiles[clickedTile].slippery;

            if (slippery) Debug.Log(clickedTile + "is slippery");
            else Debug.Log(clickedTile + "is not slippery");
        }
    }

    public bool GetTileSlipperines(Vector2 worldPosition)
    {
        Vector3Int gridPosition = map.WorldToCell(worldPosition);
        TileBase tile = map.GetTile(gridPosition);

        if (tile == null)
            return false;

        // Try to get tile data from the dictionary
        if (dataFromTiles.TryGetValue(tile, out var tileData))
        {
            return tileData.slippery;
        }

        // Tile not found in dictionary -> return false
        return false;
    }

    public void SwitchTile(bool isSlime)
    {
        if (isSlime)
        {
            BoundsInt bounds = map.cellBounds;

            foreach (Vector3Int pos in bounds.allPositionsWithin)
            {
                TileBase tile = map.GetTile(pos);

                if (tile != null)
                {
                    if (dataFromTiles.ContainsKey(tile))
                    {
                        if (dataFromTiles[tile].tileType.ToString() == "Ice")
                        {
                            map.SetColliderType(pos, Tile.ColliderType.None);
                        }
                        if (dataFromTiles[tile].tileType.ToString() == "Slime")
                        {
                            map.SetColliderType(pos, Tile.ColliderType.Sprite);
                        }
                    }
                }
            }
        }
        else
        {
            BoundsInt bounds = map.cellBounds;

            foreach (Vector3Int pos in bounds.allPositionsWithin)
            {
                TileBase tile = map.GetTile(pos);

                if (tile != null)
                {
                    if (dataFromTiles.ContainsKey(tile))
                    {
                        if (dataFromTiles[tile].tileType.ToString() == "Slime")
                        {
                            map.SetColliderType(pos, Tile.ColliderType.None);
                        }
                        if (dataFromTiles[tile].tileType.ToString() == "Ice")
                        {
                            map.SetColliderType(pos, Tile.ColliderType.Sprite);
                        }
                    }
                }
            }
        }
    }
}
