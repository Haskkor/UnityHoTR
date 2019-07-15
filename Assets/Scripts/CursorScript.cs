using System;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D movementCursor;
    
    private const CursorMode CursorMode = UnityEngine.CursorMode.Auto;
    private readonly Vector2 _hotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursor, _hotSpot, CursorMode);
    }

    private void Update()
    {
        throw new NotImplementedException();
    }
}
