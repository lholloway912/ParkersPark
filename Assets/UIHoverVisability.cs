using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverVisability : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 0; // Start invisible
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canvasGroup.alpha = 1; // Make visible
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canvasGroup.alpha = 0; // Make invisible
    }
}
