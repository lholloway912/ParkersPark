using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the object moves to the left

    void Update()
    {
        // Move the object to the left
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collides with an object tagged "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with the player. Switching to the next scene...");

            UnityEngine.SceneManagement.SceneManager.LoadScene("MapMenu");
            // SceneManager.LoadScene("CoasterWin");
        }
    }
}
