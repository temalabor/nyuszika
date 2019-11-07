using UnityEngine;

public class Float : MonoBehaviour
{
    private Rigidbody2D _rb;

    public bool onGround;
    
    public float floatHeight;
    public float liftForce;
    public float liftDamping;
    public float sideDistance;
    public float sideForce;
    public float sideDamping;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        onGround = Cast(Vector2.down, floatHeight, liftForce, liftDamping);
        Cast(Vector2.left, sideDistance, sideForce, sideDamping);
        Cast(Vector2.right, sideDistance, sideForce, sideDamping);
    }

    private bool Cast(Vector2 dir, float height, float floatForce, float damping)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, floatHeight);
        if (hit.collider == null) return false;
        
        var distance = Vector2.Distance(transform.position, hit.point);
        if (distance > height || distance < 0) return false;

        var error = height - distance;

        var force = floatForce * error - _rb.velocity.y * damping;
        _rb.AddForce(-dir * force);

        return true;
    }
}
