using UnityEngine;

public class EndCarosel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {

        if (collision.tag == "Player")

        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MapMenu");
            Debug.Log("Change Scene");
            // public void Activate(InputAction.CallbackContext context) 
            // {
            //     if (context.performed) {
            //         UnityEngine.SceneManagement.SceneManager.LoadScene("reflection");
            //     }
            // }
        }

    }
}
