using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject raser;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 0.6f;
    [SerializeField] private float minPosY = -3f;
    [SerializeField] private int maxJumpCount = 2;
    KnockBack _knockBack;
    private float _inputTimer = 0.0f;
    private bool _isButtonDown = false;
    TmpRigidbody _rb;
    private int _jumpCounter = 0;

    private void Start()
    {
        _rb = GetComponent<TmpRigidbody>();
        _knockBack = GetComponent<KnockBack>();
        GetComponent<AABBCollision>().OnAABBEnterEvent += Hit;
    }

    private void Update()
    {
        Move();
        IsGround();
        if (Input.GetButtonDown("Fire1"))
        {
            _isButtonDown = true;
            _inputTimer = 0;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (_inputTimer >= 6.0f)
            {
                ShotRaser();
            }
            else
            {
                ShotBullet();
            }
            _isButtonDown = false;
        }
        if (Input.GetButtonDown("Jump") && _jumpCounter > 0)
        {
            Jump();
            _jumpCounter--;
        }
    }

    private void FixedUpdate()
    {
        if (_isButtonDown)
        {
            _inputTimer += 0.1f;
        }
    }

    void Hit(AABBCollision other)
    {
        _knockBack.KnockbackStart(GetComponent<AABBCollision>(),other,_rb);
    }

    public void KnockBack()
    {
    }

    void ShotRaser()
    {
        GameObject tmpRaser = Instantiate(raser);
        tmpRaser.GetComponent<Raser>().ShotRaser(muzzle.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    void ShotBullet()
    {
        GameObject tmpBullet = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
        tmpBullet.transform.up = muzzle.transform.up;
    }

    void Jump()
    {
        _rb.AddForce(new Vector3(0,jumpPower,0));
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        _rb.AddSpeed(new Vector3(h * speed,0,0));
    }

    void IsGround()
    {
        if (transform.position.y + _rb.V.y < minPosY)
        {
            Vector3 tmp = transform.position;
            tmp.y = minPosY;
            this.transform.position = tmp;
            _rb.OnGround();
            _jumpCounter = maxJumpCount;
        }
    }
}