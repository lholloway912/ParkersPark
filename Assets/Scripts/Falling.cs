using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Falling : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float fallDelay = 0.4f;
    public float destroyDelay = 2.0f;

    [SerializeField] Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine (Fall());
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType= RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}

