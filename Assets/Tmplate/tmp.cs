using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class tmp : MonoBehaviour
{
    Vector3 dir;
    Vector3 _targetPos;
    [SerializeField] float _speed = 1.0f;
    void Start()
    {
        
    }
    void Update()
    {
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dot0 = Vector3.Dot(dir - this.transform.position, this.transform.right);
        if (dot0 < -0.01)
        {
            RightRotate();
        }
        else if (dot0 > 0.01)
        {
            LeftRotate();
        }
        Debug.Log(dot0);
    }

    private void RightRotate()
    {
        Vector3 _angle = this.transform.eulerAngles;
        _angle.z = _speed;
        this.transform.eulerAngles += _angle;
    }
    private void LeftRotate()
    {
        Vector3 _angle = this.transform.eulerAngles;
        _angle.z = _speed;
        this.transform.eulerAngles -= _angle;
    }
}
