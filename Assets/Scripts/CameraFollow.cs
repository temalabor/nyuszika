using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody2D follow;
    public float lookForward;
    public Vector3 offset;

    private void Update()
    {
        var fv = follow.velocity;
        var fp = follow.transform.position;
        var velocity = new Vector3(fv.x, fv.y, 0);
        
        var target = fp + velocity * lookForward + offset;

        var delta = target - transform.position;

        transform.position += delta;
    }
}
