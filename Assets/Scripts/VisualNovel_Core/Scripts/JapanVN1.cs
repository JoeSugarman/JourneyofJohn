using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JapanVN1 : MonoBehaviour
{
    DialogueSystem ds;

    TextArchitect architect;

    //buttons swithcing

    //image switching
    public UnityEngine.UI.Image shrineFrontDoor;

    private string[] currentDialogue;
    bool dialogueFinished = false;


    //first dialogue
    string[] frontDoorDialogue = new string[]
    {
        "When is the last time that I visit a shrine?",
        "I can't remember...",
        "Probably about 10 years ago.",
        "Here is so quiet, a good place for people to free up the cache inside their ram.",
        "Wait no, I should abandon all the things about computers now!",
    };


    // Start is called before the first frame update
    void Start()
    {
        ds = DialogueSystem.instance;
        architect = new TextArchitect(ds.dialogueContainer.dialogueText);
        //architect = new TextArchitect(ds.dialogueContainer.nameText);
        architect.buildMethod = TextArchitect.BuildMethod.typewriter;
        architect.speed = 0.5f;
    }

    private int currentIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (architect.isBuilding)
            {
                if (!architect.hurryUp)
                    architect.hurryUp = true;
                else
                    architect.ForceComplete();
            }
            else
            {
                if (currentIndex < currentDialogue.Length)
                {
                    architect.Build(currentDialogue[currentIndex]);
                    currentIndex++;
                }
                else
                {

                }
            }
        }
    }
                
}
