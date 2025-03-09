using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 8f;
    public bool onTopRail;
    public bool onMiddleRail;
    public bool onBottomRail;
    public float AccelerationMultiplier = 2;
    public float maxSpeed = 40;

    [Header("GroundCheck")]
    public Transform GroundcheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask TopRail;
    public LayerMask MiddleRail;
    public LayerMask BottomRail;
    public bool Death;

    [Header("CameraShake")]
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private float shakeIntensity = 0.1f;
    [SerializeField] private float shakeTime = 80f;
    public float ShakeAccelerationMultiplier = .2f;
    public float maxShake = 4f;


    void Start()
    {
        GetComponent<Renderer>().enabled = true;
        rb = GetComponent<Rigidbody2D>();
        Death = false;
    }

    void Update()
    {
        if (moveSpeed < maxSpeed)
        {
            moveSpeed += AccelerationMultiplier * Time.deltaTime;
        }
        if (shakeIntensity < maxShake)
        {
            cameraShake.ShakeCamera(shakeIntensity, shakeTime);
            shakeIntensity += ShakeAccelerationMultiplier * Time.deltaTime;
        }

        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        Dead();
        GroundCheck();

        if (onTopRail && Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, -5.411562f);
            SoundEffectManager.Play("MinecartMove");
        }
        if (onMiddleRail)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position = new Vector2(transform.position.x, -10.0607f);
                SoundEffectManager.Play("MinecartMove");
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position = new Vector2(transform.position.x, -0.92657f);
                SoundEffectManager.Play("MinecartMove");
            }
        }
        if (onBottomRail && Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector2(transform.position.x, -5.411562f);
            SoundEffectManager.Play("MinecartMove");
        }
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(GroundcheckPos.position, groundCheckSize, 0, TopRail))
        {
            onTopRail = true;
            onMiddleRail = false;
            onBottomRail = false;
        }
        else if (Physics2D.OverlapBox(GroundcheckPos.position, groundCheckSize, 0, MiddleRail))
        {
            onTopRail = false;
            onMiddleRail = true;
            onBottomRail = false;
        }
        else if (Physics2D.OverlapBox(GroundcheckPos.position, groundCheckSize, 0, BottomRail))
        {
            onTopRail = false;
            onMiddleRail = true;
            onBottomRail = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pitfall"))
        {
            Debug.Log("Hit");
            Death = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeathMenu");
        }
        if (collision.CompareTag("SceneEnd"))
        {
            Debug.Log("Scene!");
            UnityEngine.SceneManagement.SceneManager.LoadScene("MinecartBackRooms", LoadSceneMode.Single);
        }
    }

    private void Dead()
    {
        if (Death)
        {
            // rb.velocity = Vector2.zero;
            // Physics2D.IgnoreLayerCollision(0, 6, true);
            // Physics2D.IgnoreLayerCollision(0, 7, true);
            // Physics2D.IgnoreLayerCollision(0, 8, true);
        }
    }
}
