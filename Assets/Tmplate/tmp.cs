using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class tmp : MonoBehaviour
{
    Vector3 dir;
    Vector3 _targetPos;
    [SerializeField] float _speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //if (_targetPos != dir)
        //{
        //    _targetPos = Vector2.Lerp(_targetPos, dir, _speed);
        //}
        //this.transform.up = _targetPos;
        float dot0 = Vector3.Dot(dir - this.transform.position, this.transform.right);
        if (dot0 < 0)
        {
            RightRotate();
        }
        else if (dot0 > 0)
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
