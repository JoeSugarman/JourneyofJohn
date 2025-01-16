using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{
    public RectTransform content; // The content RectTransform
    public float scrollAmount = 100f; // Speed of scrolling
    public Button leftButton; // Reference to the left button
    public Button rightButton; // Reference to the right button



    private RectTransform viewport; // The viewport RectTransform
    private float contentWidth; // The total width of the content
    private float viewportWidth; // The width of the viewport

    // Start is called before the first frame update
    void Start()
    {
        // Get the viewport RectTransform
        viewport = content.parent.GetComponent<RectTransform>();

        // Calculate the content and viewport sizes
        contentWidth = content.rect.width;
        viewportWidth = viewport.rect.width;

        // Add listeners to the buttons
        leftButton.onClick.AddListener(() => Scroll(scrollAmount));
        rightButton.onClick.AddListener(() => Scroll(-scrollAmount));

        // Update button states initially
        UpdateButtonStates();
    }

    void Scroll(float amount)
    {
        // Adjust the content's anchored position
        Vector2 newPosition = content.anchoredPosition;
        newPosition.x += amount;

        // Clamp the position to prevent scrolling out of bounds
        float maxScroll = Mathf.Max(0, contentWidth - viewportWidth);
        newPosition.x = Mathf.Clamp(newPosition.x, -maxScroll, 0); //what is 0? 

        // Apply the new position
        content.anchoredPosition = newPosition;

        // Update button states
        UpdateButtonStates();
    }

    void UpdateButtonStates()
    {
        // Enable or disable buttons based on the content position
        if (leftButton != null)
            leftButton.interactable = content.anchoredPosition.x < -500;

        if (rightButton != null)
            rightButton.interactable = content.anchoredPosition.x > -(contentWidth - viewportWidth)-2000;
    }

}
