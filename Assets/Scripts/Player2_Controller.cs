using UnityEngine;

public class Player2_Controller : MonoBehaviour
{
    public float jumpVelocity = 2.4f;
    public float gravity = 150.0f;
    private Rigidbody rb;
    public SphereCollider col;
    public LayerMask groundLayers;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (GameMng.isGameRunning)
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                rb.AddForce(Vector3.forward * jumpVelocity, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(Vector3.back * gravity * Time.deltaTime);
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.center.y, col.bounds.min.z),
                                    col.radius * .9f, groundLayers);
    }
}