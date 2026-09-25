using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;

    Vector3 dir;
    [SerializeField] private Transform groundCheckPoint; // 캡슐 최하단에 배치한 빈 오브젝트
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private LayerMask floorMask;


    public bool CheckGrounded()
    {
        return Physics.CheckSphere(groundCheckPoint.position, checkRadius, floorMask);
    }
    bool isGrounded = false;
    bool jumpRequested;

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        dir = new Vector3(h, 0, v).normalized;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequested = true;
        }
    }

    private int remainingTicksAterJump = 0;
    private void FixedUpdate()
    {
        if (remainingTicksAterJump == 0)
            isGrounded = CheckGrounded();
        else
        {
            isGrounded = false;
            remainingTicksAterJump--;
        }

        Vector3 v = dir * speed;
        if (jumpRequested && isGrounded)
        {
            v.y = jumpSpeed;
            isGrounded = false;
            remainingTicksAterJump = 3;
        }
        else
            v.y = _rigidbody.linearVelocity.y;

        jumpRequested = false;

        _rigidbody.linearVelocity = v;
    }
}
