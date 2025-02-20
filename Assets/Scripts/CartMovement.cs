using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().enabled = true;
        rb = GetComponent<Rigidbody2D>();
        Death = false;
        
        

    }

    // Update is called once per frame
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
        if (onTopRail == true) 
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position = new Vector2 (transform.position.x, -5.411562f);
                SoundEffectManager.Play("MinecartMove");
               

            }
        }
        if (onMiddleRail == true)
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
        if (onBottomRail == true)
        {
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position = new Vector2(transform.position.x, -5.411562f);
                SoundEffectManager.Play("MinecartMove");


            }
        }

    }
    //all this code sets up whether or not you're on each rail//
    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(GroundcheckPos.position, groundCheckSize, 0, TopRail))
        {
            onTopRail = true;
            onMiddleRail = false;
            onBottomRail = false;
        }
        else
        if (Physics2D.OverlapBox(GroundcheckPos.position, groundCheckSize, 0, MiddleRail))
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
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {

        if (collision.tag == "Pitfall")

        {
            Debug.Log("Hit");
            Death=true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeathMenu");
            
        }
        if (collision.tag == "SceneEnd")

        {
            Debug.Log("Scene!");
            UnityEngine.SceneManagement.SceneManager.LoadScene("MinecartBackRooms", LoadSceneMode.Single);
        }
    }
    
private void Dead()
    {
        if (Death == true)
         {
//             rb.linearVelocity = new Vector2(0, 0);
//             Physics2D.IgnoreLayerCollision(0, 6, true);
//             Physics2D.IgnoreLayerCollision(0, 7, true);
//             Physics2D.IgnoreLayerCollision(0, 8, true);
         }
    }
        


//     }


}
