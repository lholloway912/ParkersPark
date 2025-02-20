using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to spawn
    public Transform spawnPoint;    // The empty GameObject's position
    public float spawnInterval = 3f; // Spawn interval in seconds
    public float moveSpeed = 5f;     // Speed at which the prefab moves to the left

    private void Start()
    {
        // Start spawning prefabs at regular intervals
        InvokeRepeating(nameof(SpawnPrefab), 0f, spawnInterval);
    }

    private void SpawnPrefab()
    {
        // Instantiate the prefab at the spawn point's position and rotation
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

        // Attach a script to move the spawned object
        spawnedObject.AddComponent<MoveLeft>().SetSpeed(moveSpeed);
    }
}

public class MoveLeft : MonoBehaviour
{
    private float speed;

    // Set the speed for the object
    public void SetSpeed(float moveSpeed)
    {
        speed = moveSpeed;
    }

    private void Update()
    {
        // Move the object to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        speed += 1f * Time.deltaTime;

        // Optional: Destroy the object after it moves out of bounds to clean up memory
        if (transform.position.x < -20f) // Adjust boundary as needed
        {
            Destroy(gameObject);
        }
    }
}
