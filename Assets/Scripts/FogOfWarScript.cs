using UnityEngine;
using UnityEngine.Tilemaps;

public class FogOfWarScript : MonoBehaviour
{
    public Tilemap fogOfWarMap;

    public void RemoveForOfWar(Vector3 position)
    {
        
        
        fogOfWarMap.SetTile(new Vector3Int(0,0,0), null); 
    }
}
