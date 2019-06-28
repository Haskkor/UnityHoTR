using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesHighlightScript : MonoBehaviour
{
    public Color color;
    private Camera _camera;
    private bool _isCameraNotNull;
    private Vector3Int _posMouseOnGrid = new Vector3Int(0, 0, 0);
    private Ray _ray;
    private Vector3Int _savePosMouseOnGrid = new Vector3Int(0, 0, 0);
    private Color _startColor;
    private Tilemap _tileMap;

    private void Start()
    {
        _camera = Camera.main;
        _isCameraNotNull = _camera != null;
        _tileMap = GetComponent<Tilemap>();
        _startColor = _tileMap.GetColor(_posMouseOnGrid);
    }

    private void Update()
    {
        if (_isCameraNotNull) _ray = _camera.ScreenPointToRay(Input.mousePosition);
        _posMouseOnGrid = _tileMap.WorldToCell(new Vector3(_ray.origin.x, _ray.origin.y, 0));
    }

    private void OnMouseOver()
    {
        if (!_tileMap.HasTile(_posMouseOnGrid)) return;
        _tileMap.SetTileFlags(_posMouseOnGrid, TileFlags.None);
        if (_savePosMouseOnGrid != _posMouseOnGrid)
        {
            _tileMap.SetColor(_savePosMouseOnGrid, _startColor);
            _savePosMouseOnGrid = _posMouseOnGrid;
        }
        _tileMap.SetColor(_posMouseOnGrid, new Color(color.r, color.g, color.b));
    }

    private void OnMouseExit()
    {
        _tileMap.SetColor(_posMouseOnGrid, _startColor);
    }
}