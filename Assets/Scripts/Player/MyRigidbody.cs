using UnityEngine;
[DefaultExecutionOrder(-99)]
public class MyRigidbody : MonoBehaviour
{
    [SerializeField] private float _gravity = 0.05f;
    private Vector3 _v = Vector3.zero;

    private Vector3 VForce
    {
        get { return _v; }
        set { _v = value; }
    }

    private Vector3 VSpeed
    {
        get { return _v; }
        set { _v = value; }
    }

    public Vector3 V
    {
        get => _v;
        set => _v = value;
    }
    private void FixedUpdate()
    {
        TmpRigid();
    }

    void TmpRigid()
    {
        AddForce(new Vector3(0,-_gravity,0));
        transform.position += V;
    }

    public void AddSpeed(Vector3 vector3)
    {
        VSpeed = vector3;
    }

    public void AddForce(Vector3 vector3)
    {
        VForce += vector3;
    }

    public void OnGround()
    {
        Vector3 v = VForce;
        v.y = 0;
        VForce = v;
    }
}