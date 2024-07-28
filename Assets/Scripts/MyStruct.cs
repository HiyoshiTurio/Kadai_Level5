using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStruct : MonoBehaviour
{
    
}
public struct Rect
{
    public float Right;
    public float Left;
    public float Top;
    public float Bottom;

    public Rect(float right, float left, float top, float bottom)
    {
        Right = right;
        Left = left;
        Top = top;
        Bottom = bottom;
    }
}
