using System.Collections;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool Death;
    [Header("Movement")]
    public Rigidbody2D rb;
    public float movespeed = 5f;
    float horizontalMovement;
    public float jumpPower = 10f;
    public int maxJumps = 2;
    int jumpsRemaining;
    public float dashSpeed = 200f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 0.1f;
    bool canDash = true;
    bool isDashing;
    public bool isFacingRight = true;
    public bool dashing = false;
    TrailRenderer trailRenderer;

    [Header("GroundCheck")]
    public Transform GroundcheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("Gravity")]
    public float baseGravity = 2f;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;

    [Header("Animation")]

    public Animator animator;
    public ParticleSystem smokeFX;
    public TrailRenderer TrailRenderer;
    

    void Start()
    {
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
        trailRenderer = GetComponent<TrailRenderer>();
        Death = false;

    }

    // Update is called once per frame
    void Update()
    {
        //this makes him move//
        rb.linearVelocity = new Vector2(horizontalMovement * movespeed, rb.linearVelocity.y);

        if (isDashing)
        {
            return;
        }
            

        //ground Check always updates//
        GroundCheck();
        Gravity();
        Flip();
        Dead();
        animator.SetFloat("magnitude", rb.linearVelocity.magnitude);
        animator.SetBool("Jump", rb.linearVelocityY >0);
    }
    private void Flip()
    {
        if (isFacingRight && horizontalMovement < 0 || !isFacingRight && horizontalMovement > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    //This one asks for leftnRight input//
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
    // This one is Dashing//
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
        {
            StartCoroutine(DashCoroutine());
        }
    }
    private IEnumerator DashCoroutine()
    {
        canDash= false;
        isDashing = true;
        TrailRenderer.emitting = true;

        float dashDirection = isFacingRight ? 1f : -1f;

        movespeed = dashSpeed;
        fallSpeedMultiplier = 0f;

        yield return new WaitForSeconds(dashDuration);

        movespeed = 11f;
        fallSpeedMultiplier = 2.5f;

        isDashing = false;
        trailRenderer.emitting = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }
    


    //This one asks for Jump//
    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                jumpsRemaining--;
                smokeFX.Play();
            }
            else if (context.canceled)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                jumpsRemaining--;
                smokeFX.Play();
            }

        }
    }
    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(GroundcheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaining = 2;
        }
    }
    private void Gravity()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }
    private void OnDrawGizmosSelected()
    {
        // Gizmos.color = Color.white;
        Gizmos.DrawWireCube(GroundcheckPos.position, groundCheckSize);
    }
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {

        if (collision.tag == "Pitfall")

        {
            Debug.Log("Hit");
            Death = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeathMenu");

        }
        if (collision.tag == "SceneEnd")

        {
            Debug.Log("Scene!");

        }
    }
    private void Dead()
    {
        if (Death == true)
        {
            // rb.linearVelocity = new Vector2(0, 0);
            // Physics2D.IgnoreLayerCollision(0, 6, true);
            // Physics2D.IgnoreLayerCollision(0, 7, true);
            // Physics2D.IgnoreLayerCollision(0, 8, true);
            
        }



    }
}
    

