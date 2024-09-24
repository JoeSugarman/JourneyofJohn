using UnityEngine;
using UnityEngine.UI;

public class AlphaControl : MonoBehaviour
{
    public Image image; // The UI Image component
    public float speed = 1f; // Speed of the alpha transition

    private bool fadingOut = true;
    private float targetAlphaMin = 0.5f; // 50% transparency
    private float targetAlphaMax = 1f; // 100% transparency

    void Update()
    {
        // Get the current color of the image
        Color currentColor = image.color;

        // Determine whether to fade in or out
        if (fadingOut)
        {
            // Fade to 50% alpha
            currentColor.a -= speed * Time.deltaTime;
            if (currentColor.a <= targetAlphaMin)
            {
                currentColor.a = targetAlphaMin;
                fadingOut = false; // Start fading in
            }
        }
        else
        {
            // Fade back to 100% alpha
            currentColor.a += speed * Time.deltaTime;
            if (currentColor.a >= targetAlphaMax)
            {
                currentColor.a = targetAlphaMax;
                fadingOut = true; // Start fading out
            }
        }

        // Apply the new alpha to the image
        image.color = currentColor;
    }
}

