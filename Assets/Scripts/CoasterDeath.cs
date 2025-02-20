using UnityEngine;

public class CoasterDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collides with an object tagged "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("You died");
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeathMenu");
        }
    }
}
