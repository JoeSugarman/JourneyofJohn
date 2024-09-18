using UnityEngine;
using UnityEngine.UI;

public class CloudLooper : MonoBehaviour
{
    public float speed = 2f;   // Speed at which the cloud moves
    public float resetPositionX;  // The X position to reset the cloud to (off-screen)
    public float startPositionX;  // The X position where the cloud starts (off-screen or edge of the screen)
    private RectTransform cloudRectTransform;

    void Start()
    {
        // Get the RectTransform of the UI Image (cloud)
        cloudRectTransform = GetComponent<RectTransform>();

        // Set the initial position
        cloudRectTransform.anchoredPosition = new Vector2(startPositionX, cloudRectTransform.anchoredPosition.y);
    }

    void Update()
    {
        // Move the cloud to the left
        cloudRectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        // Check if the cloud has moved off the screen
        if (cloudRectTransform.anchoredPosition.x < resetPositionX)
        {
            // Reset the cloud's position to the start
            cloudRectTransform.anchoredPosition = new Vector2(1516, cloudRectTransform.anchoredPosition.y);
        }
    }

    private bool checkOutScreen()
    {
        bool isOut = false;
        if (cloudRectTransform.anchoredPosition.x < resetPositionX)
        {
            isOut = true;
        }

        return isOut;
    }

}
