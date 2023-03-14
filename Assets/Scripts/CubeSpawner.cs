using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(_cube);
        }


    }
}