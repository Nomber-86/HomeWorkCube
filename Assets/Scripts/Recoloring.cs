using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Recoloring : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private float _recoloringTime = 3f;
    [SerializeField] private float _colorChangeTime = 3f;

    private Renderer _renderer;
    private Color _startColor;
    private Color _nextColor;
    private float _currentTime;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateRandomColor();
    }


    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _recoloringTime)
        {
            if (_currentTime >= _recoloringTime + _colorChangeTime)
            {
                GenerateRandomColor();
                _currentTime = 0f;
            }
        }
        else
        {
            var progress = _currentTime / _recoloringTime;
            var currentColor = Color.Lerp(_startColor, _nextColor, progress);
            _renderer.material.color = currentColor;
        }
    }


    private void GenerateRandomColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }
}