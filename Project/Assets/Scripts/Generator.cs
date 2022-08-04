using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Generator : MonoBehaviour
{
    [SerializeField] Tile landTile;
    [SerializeField] Tile waterTile;

    [SerializeField] Tilemap tilemap;

    [SerializeField] Vector2 mapSize;

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Tile tile;

                if (Random.Range(0, 2) == 0)
                    tile = landTile;
                else
                    tile = waterTile;


                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }

        for (int i = 0; i < 10; i++)
        {
            Smooth();
        }
    }

    void Smooth()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                int landTileCount = 0;


                // 0 0 0
                // $ 0 0
                // 0 0 0
                if (tilemap.GetTile(new Vector3Int(x - 1, y, 0)) == landTile)
                {
                    landTileCount++;
                }

                // 0 0 0
                // 0 0 0
                // $ 0 0
                if (tilemap.GetTile(new Vector3Int(x - 1, y - 1, 0)) == landTile)
                {
                    landTileCount++;
                }

                // 0 0 0
                // 0 0 0
                // 0 $ 0
                if (tilemap.GetTile(new Vector3Int(x, y - 1, 0)) == landTile)
                {
                    landTileCount++;
                }

                // 0 0 0
                // 0 0 0
                // 0 0 $
                if (tilemap.GetTile(new Vector3Int(x + 1, y - 1, 0)) == landTile)
                {
                    landTileCount++;
                }

                // 0 0 0
                // 0 0 $
                // 0 0 0
                if (tilemap.GetTile(new Vector3Int(x + 1, y, 0)) == landTile)
                {
                    landTileCount++;
                }

                // 0 0 $
                // 0 0 0
                // 0 0 0
                if (tilemap.GetTile(new Vector3Int(x + 1, y + 1, 0)) == landTile)
                {
                    landTileCount++;
                }

                // 0 $ 0
                // 0 0 0
                // 0 0 0
                if (tilemap.GetTile(new Vector3Int(x, y + 1, 0)) == landTile)
                {
                    landTileCount++;
                }

                // $ 0 0
                // 0 0 0
                // 0 0 0
                if (tilemap.GetTile(new Vector3Int(x - 1, y + 1, 0)) == landTile)
                {
                    landTileCount++;
                }

                if(landTileCount > 4)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), landTile);
                }
                else if(landTileCount < 4)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), waterTile);
                }
            }
        }
    }

    void Update()
    {
    }
}
