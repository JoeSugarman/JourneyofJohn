using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace TESTING
{
    public class JapanVN1 : MonoBehaviour
    {
        DialogueSystem ds;

        TextArchitect architect;

        //buttons swithcing
        public UnityEngine.UI.Button VN1Continue1;

        //image switching
        public UnityEngine.UI.Image shrineFrontDoor;
        public UnityEngine.UI.Image shrineInside;

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

        //second dialogue
        string[] prayInFrontOFShrine = new string[]
        {
            "Dear God, I have just quit my job.",
            "I don't think I should stay in the office for whole of my life. I want to finish my bucket list before I die.",
            "Not because I want to be different from other, but I do not want to feel regret when I become old.",
            "I feel like I am a robot everyday...",
            "Could I get your help to fulfil my dream?",
            "Plzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz"
        };


        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            //architect = new TextArchitect(ds.dialogueContainer.nameText);
            architect.buildMethod = TextArchitect.BuildMethod.typewriter;
            architect.speed = 0.5f;

            //assign the first dialogue
            currentDialogue = frontDoorDialogue;

            //add a listerner for the button click
            VN1Continue1.onClick.AddListener(enterIntoTheShrine);

            //deactivate all images
            if (shrineInside != null)
                shrineInside.gameObject.SetActive(false);

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
                        if(currentDialogue == frontDoorDialogue)
                        {
                            //activate the button
                            VN1Continue1.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }

        void enterIntoTheShrine()
        {
            //change background
            shrineFrontDoor.gameObject.SetActive(false);
            shrineInside.gameObject.SetActive(true);

            //load new dialogue
            currentDialogue = prayInFrontOFShrine;
            currentIndex = 0;

            //deactivate the button
            VN1Continue1.gameObject.SetActive(false);

            if (currentIndex < currentDialogue.Length)
            {
                // Start the new dialogue sequence
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

    }
}
