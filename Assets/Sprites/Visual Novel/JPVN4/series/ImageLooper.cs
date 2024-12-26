using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageLooper : MonoBehaviour
{
    public Image VN4Images; // The UI Image component to display the frames
    public Sprite[] frames;    // Array of sprites (video frames)
    public float frameRate = 15f; // Frames per second


    // Start is called before the first frame update
    void Start()
    {
        if (frames.Length > 0)
        {
            StartCoroutine(PlayFrames());
        }
    }

    private IEnumerator PlayFrames()
    {
        int frameIndex = 0;
        float frameDelay = 1f / frameRate;

        while (true)
        {
            // Set the current frame
            VN4Images.sprite = frames[frameIndex];

            // Move to the next frame
            frameIndex = (frameIndex + 1) % frames.Length;

            // Wait for the next frame
            yield return new WaitForSeconds(frameDelay);
        }
    }
}

