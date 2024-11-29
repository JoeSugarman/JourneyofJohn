using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
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
            Debug.Log("Interact key pressed");
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

        //iunteract with options
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    private void ChangePosition(int _change)
    {
        currentPosition += _change;

        if(_change!=0)
            SoundManager.instance.PlaySound(changeSound);

        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if(currentPosition > options.Length - 1)
            currentPosition = 0;

        //moving it up or down
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0); 
    }

    private void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);

        //interact with each option and call it's function
        options[currentPosition].GetComponent<Button>().onClick.Invoke();


    }
}
