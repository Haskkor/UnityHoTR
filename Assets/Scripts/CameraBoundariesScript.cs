using UnityEngine;

public class CameraBoundariesScript : MonoBehaviour
{
    public int margin = 50;
    public int speed = 5;

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
        var position = transformCamera.position;
        var newX = position.x; 
        var newY = position.y; 
        
        if (Input.mousePosition.x > _screenWidth - margin) newX += speed * Time.deltaTime;
        if (Input.mousePosition.x < 0 + margin) newX -= speed * Time.deltaTime;
        if (Input.mousePosition.y > _screenHeight - margin) newY += speed * Time.deltaTime;
        if (Input.mousePosition.y < 0 + margin) newY -= speed * Time.deltaTime;

        transformCamera.position = new Vector3(newX, newY, transformCamera.position.z);
    }
}
