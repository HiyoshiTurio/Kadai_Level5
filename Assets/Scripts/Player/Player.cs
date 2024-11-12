using UnityEngine;

public class Player : CharacterBase
{
    [SerializeField] private GameObject raser;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 0.6f;
    [SerializeField] private float minPosY = -3f;
    [SerializeField] private int maxJumpCount = 2;
    private PlayerState _playerState;
    private bool _isButtonDown = false;
    private float _inputTimer = 0.0f;
    private int _jumpCounter = 0;

    void Start()
    {
        _playerState = GetComponent<PlayerState>();
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
        Rb.AddForce(new Vector3(0,jumpPower,0));
    }

    void Move()
    {
        if (_isStunned == false)
        {
            float h = Input.GetAxis("Horizontal");
            Rb.AddSpeed(new Vector3(h * speed,0,0));
        }
    }

    void IsGround()
    {
        if (transform.position.y + Rb.V.y < minPosY)
        {
            Vector3 tmp = transform.position;
            tmp.y = minPosY;
            this.transform.position = tmp;
            Rb.OnGround();
            _jumpCounter = maxJumpCount;
        }
    }
}