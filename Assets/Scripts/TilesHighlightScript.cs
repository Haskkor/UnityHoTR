using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesHighlightScript : MonoBehaviour
{
    private Color _startColor;
    private Renderer _renderer;
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        Debug.Log("Test");
        var material = _renderer.material;
        _startColor = material.color;
        material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
