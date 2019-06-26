using System.Security.Cryptography;
using UnityEngine;

public class CameraBoundariesScript : MonoBehaviour
{
    public int margin = 50;
    public int speedBoundaries = 10;
    public float speedDrag = 25f;

    private int _screenWidth;
    private int _screenHeight;
    private Camera _camera;
    private bool _isCameraNull;

    private void Start()
    {
        _camera = Camera.main;
        _isCameraNull = _camera == null;
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
    }

    private void Update()
    {
        if (_isCameraNull) return;
        var transformCamera = _camera.transform;
        if (Input.GetMouseButton(2)) DragCamera(transformCamera);
//        else BoundariesCamera(transformCamera);
    }

    private void DragCamera(Transform transformCamera)
    {
        transformCamera.position += new Vector3(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * speedDrag,
            -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speedDrag, 0f);
    }

    private void BoundariesCamera(Transform transformCamera)
    {
        var position = transformCamera.position;
        var newX = position.x;
        var newY = position.y;
        if (Input.mousePosition.x > _screenWidth - margin) newX += speedBoundaries * Time.deltaTime;
        if (Input.mousePosition.x < 0 + margin) newX -= speedBoundaries * Time.deltaTime;
        if (Input.mousePosition.y > _screenHeight - margin) newY += speedBoundaries * Time.deltaTime;
        if (Input.mousePosition.y < 0 + margin) newY -= speedBoundaries * Time.deltaTime;
        transformCamera.position = new Vector3(newX, newY, position.z);
    }
}