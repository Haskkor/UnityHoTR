using UnityEngine;
using UnityEngine.Tilemaps;

public class FogOfWarScript : MonoBehaviour
{
    public Tilemap fogOfWarMap;

    public void RemoveFogOfWar(Vector3Int position)
    {
        Debug.Log("In method");
        fogOfWarMap.SetTile(position, null); 
    }
}
