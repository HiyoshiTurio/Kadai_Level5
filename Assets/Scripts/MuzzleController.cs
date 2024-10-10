using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleController : MonoBehaviour
{
    [SerializeField] GameObject _muzzleObj;
    Camera _mainCamera;
    void Start()
    {
        _mainCamera = Camera.main;
    }
    void Update()
    {
        Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - _muzzleObj.transform.position.y,
            mousePos.x - _muzzleObj.transform.position.x);
        _muzzleObj.transform.rotation = Quaternion.AngleAxis(angle * 180 / Mathf.PI, new Vector3(0, 0, 1));
    }
}
