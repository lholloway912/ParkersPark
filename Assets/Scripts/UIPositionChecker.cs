using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPositionChecker : MonoBehaviour
{
    [System.Serializable]
    public class UIObject
    {
        public RectTransform uiObject;       // The UI object to be checked
        public RectTransform targetPosition; // The correct position for this UI object
        public float tolerance = 10f;        // How close the object needs to be to the target
        public bool isCorrect = false;       // Tracks whether the object is in the correct position
    }

    public UIObject[] uiObjects; // List of UI objects to check
    public string nextSceneName; // Name of the scene to load

    void Update()
    {
        // Check if all objects are in the correct position
        if (AreAllObjectsInPlace())
        {
            LoadNextScene();
        }
    }

    private bool AreAllObjectsInPlace()
    {
        foreach (var uiObject in uiObjects)
        {
            // Check the distance between the object and its target
            float distance = Vector2.Distance(uiObject.uiObject.anchoredPosition, uiObject.targetPosition.anchoredPosition);

            // Update the isCorrect flag
            uiObject.isCorrect = distance <= uiObject.tolerance;

            // If any object is not in place, return false
            if (!uiObject.isCorrect)
            {
                return false;
            }
        }
        return true; // All objects are in place
    }

    private void LoadNextScene()
    {
        Debug.Log("All UI objects are in the correct place! Loading next scene...");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GearWin");
    }
}
