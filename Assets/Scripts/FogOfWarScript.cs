using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FogOfWarScript : MonoBehaviour
{
    public Tilemap fogOfWarMap;

    public void RemoveFogOfWar(Vector3Int position)
    {
        var neighbors = getNeighbors(position);
        foreach (var row in neighbors)
        {
            foreach (var tile in row)
            {
                fogOfWarMap.SetTile(tile, null);
            }
        }
    }

    private IEnumerable<Vector3Int[]> getNeighbors(Vector3Int position)
    {
        var isEven = position.y % 2 == 0;
        Vector3Int[] row1 =
        {
            new Vector3Int(isEven ? position.x - 1 : position.x, position.y + 1, position.z),
            new Vector3Int(isEven ? position.x : position.x + 1, position.y + 1, position.z)
        };
        Vector3Int[] row2 =
        {
            new Vector3Int(position.x - 1, position.y, position.z),
            new Vector3Int(position.x, position.y, position.z),
            new Vector3Int(position.x + 1, position.y, position.z)
        };
        Vector3Int[] row3 =
        {
            new Vector3Int(isEven ? position.x - 1 : position.x, position.y - 1, position.z),
            new Vector3Int(isEven ? position.x : position.x + 1, position.y - 1, position.z)
        };
        Vector3Int[][] neighbors = {row1, row2, row3};
        return neighbors;
    }
}