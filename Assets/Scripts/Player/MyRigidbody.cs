using UnityEngine;
[DefaultExecutionOrder(-99)]
public class MyRigidbody : MonoBehaviour
{
    [SerializeField] private float _gravity = 0.05f;
    private Vector3 _v = Vector3.zero;

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
        V = vector3;
    }

    public void AddForce(Vector3 vector3)
    {
        V += vector3;
    }

    public void OnGround()
    {
        Vector3 v = V;
        v.y = 0;
        V = v;
    }
}