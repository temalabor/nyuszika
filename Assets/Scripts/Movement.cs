using UnityEngine;

public class Movement : MonoBehaviour
{
    public delegate void MovementDelegate();
    public event MovementDelegate JumpEvent;
    public event MovementDelegate WalkEvent;
    public event MovementDelegate SlideEvent;
    public event MovementDelegate NoneEvent;
    
    public float jumpVelocity;
    public float jumpDamping;
    public float downForce;
    public float fallSpeed;
    public float sideForce;
    public float sideVelocity;
    public float moveDamping;
    public bool sliding;
    public float slideVelocity;
    public float slideDamping;

    private Rigidbody2D _rb;
    private Float _floatScript;

    private bool _left,
        _right,
        _jump,
        _down,
        _none = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _floatScript = GetComponent<Float>();
    }

    private void Update()
    {
        HandleKeys();
        if (_jumpTimer < jumpTime) _jumpTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        sliding = _down;

        if (_jump) Jump();
        if (_down) Down();
        if (_left) Left();
        if (_right) Right();
        if (_none)
        {
            DampMovement(_floatScript.onGround ? moveDamping : jumpDamping);
            NoneEvent?.Invoke();
        }
    }

    private void HandleKeys()
    {
        _left = Input.GetKey(KeyCode.A);
        _right = Input.GetKey(KeyCode.D);
        _jump = Input.GetKey(KeyCode.Space);
        _down = Input.GetKey(KeyCode.S);

        _none = !(_left || _right || _jump || _down);
    }

    private float _jumpTimer;
    public float jumpTime = 0.5f;

    private void Jump()
    {
        if (!_floatScript.onGround) return;
        if (_jumpTimer < jumpTime) return;

        _rb.velocity += Vector2.up * jumpVelocity;
        _jumpTimer = 0f;
        
        JumpEvent?.Invoke();
    }

    private void Down()
    {
        if (_rb.velocity.y > -fallSpeed) _rb.AddForce(Vector2.down * (downForce * Time.deltaTime));
        DampMovement(slideDamping);
    }

    private void Left()
    {
        if (!sliding && _rb.velocity.x > -sideVelocity)
        {
            _rb.AddForce(Vector2.left * (sideForce * _rb.mass * Time.deltaTime));
        }

        if (sliding && _rb.velocity.x > -slideVelocity)
        {
            _rb.AddForce(Vector2.left * (sideForce * _rb.mass * Time.deltaTime));
        }
        
        if(_floatScript.onGround && !sliding) WalkEvent?.Invoke();
        if(_floatScript.onGround && sliding) SlideEvent?.Invoke();
    }

    private void Right()
    {
        if (!sliding && _rb.velocity.x < sideVelocity)
        {
            _rb.AddForce(Vector2.right * (sideForce * _rb.mass * Time.deltaTime));
        }

        if (sliding && _rb.velocity.x < slideVelocity)
        {
            _rb.AddForce(Vector2.right * (sideForce * _rb.mass * Time.deltaTime));
        }
        
        if(_floatScript.onGround && !sliding) WalkEvent?.Invoke();
        if(_floatScript.onGround && sliding) SlideEvent?.Invoke();
    }

    private void DampMovement(float damping)
    {
        var velocity = _rb.velocity;
        _rb.AddForce(new Vector2(-velocity.x, 0).normalized * (damping * velocity.magnitude));
    }
}