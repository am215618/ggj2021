using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    void LateUpdate()
    {
        transform.forward = _camera.transform.forward;
    }
}
