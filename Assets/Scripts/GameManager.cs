using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    // coaster game
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }


    // ui
    public GameObject gameOverUI;

        private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            DestroyImmediate(gameObject);
        }
    }

    public void OnDestroy() {
        if (Instance == this) {
            Instance = null;
        }
    }

    public void Start() {


        NewGame();
    }

    public void NewGame() {
        gameSpeed = initialGameSpeed;
    }


    private void Update() {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.P)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }

    }

    public void Reflection() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("reflection");
        Debug.Log("Change Scene");
    }

    // public void Wires() {
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("WireMinigame");
    //     Debug.Log("Change Scene");
    // }

    public void Carousel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Carousel");
        Debug.Log("Carousel has Loaded.");
    }

    public void MapMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MapMenu");
        Debug.Log("MapMenu has Loaded.");
    }

    public void MinecartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MinecartLevel");
        Debug.Log("Haunted House has Loaded.");
    }

    public void WoodenCoaster()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WoodenCoaster");
        Debug.Log("Coaster has Loaded.");
    }





    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void mainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
