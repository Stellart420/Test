using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Joystick joystick;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movement);

        if (movement.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
