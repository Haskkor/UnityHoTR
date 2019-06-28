using UnityEngine;

public class ZoomMapScript : MonoBehaviour
{
    private Camera _camera;
    private float _maxZoom = 3f;
    private float _minZoom = 15f;
    private float _speed = 3f;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && _camera.orthographicSize > _maxZoom)
        {
            _camera.orthographicSize -= .1f * _speed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && _camera.orthographicSize < _minZoom)
        {
            _camera.orthographicSize += .1f * _speed;
        }
    }
}