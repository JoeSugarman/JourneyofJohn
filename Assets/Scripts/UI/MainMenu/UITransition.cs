using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITransition : MonoBehaviour
{
    // Starting and ending points
    [SerializeField] private Vector2 pointA; // Initial position
    [SerializeField] private Vector2 pointB; // Target position

    // Duration of the transition (in seconds)
    public float duration = 3f;

    // Reference to check if the object is moving
    private bool isMoving = false;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        // Set the object to its initial position (point A)
        rectTransform.anchoredPosition = pointA;
    }

    // This method will be called when the button is pressed
    public void StartMoving()
    {
        // Start the movement coroutine only if the object is not already moving
        if (!isMoving)
        {
            StartCoroutine(MoveFromAToB());
        }
    }

    // Coroutine to smoothly move the object from point A to point B
    IEnumerator MoveFromAToB()
    {
        isMoving = true;
        float elapsedTime = 0f;

        // Capture the starting position for the interpolation
        Vector2 startPosition = rectTransform.anchoredPosition;

        // Move the object over the duration
        while (elapsedTime < duration)
        {
            // Interpolate between the starting position and point B
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, pointB, elapsedTime / duration);

            // Increment the elapsed time by the time passed since the last frame
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the object ends at point B
        //transform.position = pointB;
        rectTransform.anchoredPosition = pointB;

        // Mark the movement as complete
        isMoving = false;
    }
}
