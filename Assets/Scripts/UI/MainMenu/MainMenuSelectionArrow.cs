using UnityEngine;
using UnityEngine.UI;

public class MainMenuSelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    [SerializeField] private AudioClip changeSound; //the sound we play when we change the selection
    [SerializeField] private AudioClip interactSound; //the sound we play when we interact with the selection
    private RectTransform rect;
    private int currentPosition;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        //change position of the selection arrow
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosition(-1);
            Debug.Log("helloworld");
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

        //iunteract with options
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E))
        { 
            Interact();
            Debug.Log("helloworld");
        }
    }


    private void ChangePosition(int _change)
    {
        float column1X = 631.0f; // Set to your first column x position
        //float column2X = -522.0f; // Set to your second column x position

        currentPosition += _change;

        //if (_change != 0)
        //    SoundManager.instance.PlaySound(changeSound);

        // Handle circular navigation
        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
            currentPosition = 0;

        // Determine x and y position based on the current position and column layout
        Vector3 newPos = rect.position;

        // Assuming options 0-3 are in the first column and 4+ are in the second column
        if (currentPosition < 5) // First column (options 0-3)
        {
            newPos.x = column1X;  // Set to your first column x position
        }
        //else // Second column (options 4 and above)
        //{
        //    newPos.x = column2X;  // Set to your second column x position

        //}

        // Update the y position based on the current option's y position
        newPos.y = options[currentPosition].position.y;

        // Apply the new position to the arrow
        rect.position = new Vector3(newPos.x, newPos.y, 0);
    }


    private void Interact()
    {
        //SoundManager.instance.PlaySound(interactSound);

        //interact with each option and call it's function
        options[currentPosition].GetComponent<Button>().onClick.Invoke();


    }
}
