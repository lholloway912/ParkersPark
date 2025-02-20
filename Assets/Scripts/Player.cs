using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 7f * 2f;
    public float jumpForce = 8f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (!character.isGrounded)
        {
            direction += Vector3.down * gravity * Time.deltaTime;
        }
        else
        {
            direction.y = 0;

            if (Input.GetButton("Jump"))
            {
                direction.y = jumpForce;
                animator.SetBool("isJumping", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }

        character.Move(direction * Time.deltaTime);
    }
}
