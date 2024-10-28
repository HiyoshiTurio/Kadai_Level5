using UnityEngine;

public class Raser : MonoBehaviour
{
    [SerializeField] private float instanceTime = 0.2f;
    [SerializeField] private int damage = 3;
    void Start()
    {
        Destroy(this.gameObject, instanceTime);
    }
    public void ShotRaser(Vector3 pivot, Vector3 mousePos)
    {
        this.transform.position = pivot;
        this.transform.right = new Vector3(mousePos.x - pivot.x, mousePos.y - pivot.y, 0);
        ColliderManager.Instance.CheckRaser(pivot, transform.right , this );
    }

    public void Hit(AABBCollision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().Hp -= damage;
        }
    }
}
