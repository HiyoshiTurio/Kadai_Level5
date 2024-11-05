using UnityEngine;
[DefaultExecutionOrder(-99)]
public class TmpRigidbody : MonoBehaviour
{
    [SerializeField] private float _gravity = 0.05f;
    private Vector3 _v = Vector3.zero;
    private Vector3 _vForce = Vector3.zero;
    private Vector3 _vSpeed = Vector3.zero;

    public Vector3 V => _vForce + _vSpeed;
    

    private void FixedUpdate()
    {
        TmpRigid();
    }

    void TmpRigid()
    {
        AddForce(new Vector3(0,-_gravity,0));
        transform.position += V;
        _vSpeed = Vector3.zero;
    }

    public void AddSpeed(Vector3 vector3)
    {
        _vSpeed += vector3;
    }

    public void AddForce(Vector3 vector3)
    {
        _vForce += vector3;
    }

    public void OnGround()
    {
        _vForce.y = 0;
    }
}