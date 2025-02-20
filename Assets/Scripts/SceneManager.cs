using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    public void  NextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MinecartBackRooms", LoadSceneMode.Single);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
