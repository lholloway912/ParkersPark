using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class Enable : MonoBehaviour
{
    public Canvas canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // public void Activate(InputAction.CallbackContext context) {
    //     if (context.performed) {
    //         UnityEngine.SceneManagement.SceneManager.LoadScene("reflection");
    //         Debug.Log("Change Scene");
    //         }
    //     }
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {

        if (collision.tag == "Player")

        {
            Debug.Log("Hit");
            canvas.enabled = true;
            // public void Activate(InputAction.CallbackContext context) 
            // {
            //     if (context.performed) {
            //         UnityEngine.SceneManagement.SceneManager.LoadScene("reflection");
            //     }
            // }
        }

             
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.enabled = false;
        }
    }
}
