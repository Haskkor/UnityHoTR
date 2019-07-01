using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainCharacterMoveScript : MonoBehaviour
{
    public float speed = 3f;
    public float startPositionX = -16.6f;
    public float startPositionY = 30.0f;
    public Tilemap tileMap;

    private Camera _camera;
    private bool _isMainNotNull;
    private Vector3 _newTilePosition;
    private Vector3Int _posMouseOnGrid;
    private Ray _ray;

    private const float XOffset = 1.3f;
    private const float YOffset = 2.5f;

    private void Start()
    {
        _camera = Camera.main;
        _isMainNotNull = _camera != null;
        _newTilePosition = new Vector3(startPositionX, startPositionY, transform.position.z);
    }

    private void Update()
    {
        if (_isMainNotNull && Input.GetMouseButtonDown(0) && transform.position == _newTilePosition)
        {
            _newTilePosition = GetNewPosition();
            _newTilePosition.x += GetXOffset();
            _newTilePosition.y += YOffset;
            _newTilePosition.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, _newTilePosition, speed * Time.deltaTime);
    }

    private Vector3 GetNewPosition()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        _posMouseOnGrid = tileMap.WorldToCell(new Vector3(_ray.origin.x, _ray.origin.y, 0));
        return tileMap.GetCellCenterWorld(_posMouseOnGrid);
    }

    private float GetXOffset()
    {
        var isRightOffset = _posMouseOnGrid.y % 2 == 0;
        if (isRightOffset) return -XOffset;
        return XOffset;
    }
}