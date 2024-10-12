using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;

        TextArchitect architect;

        //buttons for first interaction yes and no
        public UnityEngine.UI.Button button1;
        public UnityEngine.UI.Button button2;
        public UnityEngine.UI.Button button3;

        //images swithching
        public UnityEngine.UI.Image officeWorkingImage;
        public UnityEngine.UI.Image quitJobLetterImage;

        private string[] currentDialogue;


        //first loading self talk
        string[] firstSelfTalk = new string[]
        {
            "Another day, another line of code.",
            "Debug. Compoile. Repeat. I keep doing this everyday, it feels like an infinite loop in my life.",
            "Sigh. Why am I doing this? Why did this become the whole part of my life?",
            "Who am I?",
            "Why am I doing this?",
            "Should I quit the job?"
        };

        //yes button self talk
        string[] button1SelfTalk = new string[]
        {
            "Yea! I should quit the job.",
            "My life should be much more colorful!",
            "I feel like it is black and white only now...",
            "I should find something much more cool and interesting to do",
            "Visiting the world on foot?",
            "Hummm...",
            "Anyways, let me quit the job first :>"
        };

        //no button self talk
        string[] button2SelfTalk = new string[]
        {
            "But I don't want to stay in here for my whole life",
            "Should I quit the job?"
        };

        //quit job letter self talk
        string[] continueSelfTalk = new string[]
        {
            "What a good day to hand in my resignation letter!",
            "haha",
            "This probably the best moment in my life ;)"
        };


        private int currentIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            //architect = new TextArchitect(ds.dialogueContainer.nameText);
            architect.buildMethod = TextArchitect.BuildMethod.typewriter;
            architect.speed = 0.5f;

            // Assign initial dialogue set
            currentDialogue = firstSelfTalk;

            // Add a listener for the button click
            button1.onClick.AddListener(YesButtonClick);
            button2.onClick.AddListener(NoButtonClick);
            button3.onClick.AddListener(switchImageClick);

            if (quitJobLetterImage != null)
                quitJobLetterImage.gameObject.SetActive(false);
        }

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
                        if (currentDialogue == firstSelfTalk)
                        {
                            button1.gameObject.SetActive(true);
                            button2.gameObject.SetActive(true);
                        }
                        else if (currentDialogue == button1SelfTalk)
                        {
                             button3.gameObject.SetActive(true);
                        }
                        else if (currentDialogue == button2SelfTalk)
                        {
                            button1.gameObject.SetActive(true);
                            button2.gameObject.SetActive(true);
                        }
                    }
                }
            }
            //else if (Input.GetKeyDown(KeyCode.A))
            //{
            //    architect.Append(lines[Random.Range(0, lines.Length)]);
            //}
        }

        void YesButtonClick()
        {
            // Load the new string array for dialogues
            currentDialogue = button1SelfTalk;

            // Reset the index and continue with the new dialogues
            currentIndex = 0;

            // Hide the button again (if needed)
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);

            // Start the new dialogue sequence
            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }

            UpdateDialogueAfterYes();
        }

        void NoButtonClick()
        {
            // Load the new string array for dialogues
            currentDialogue = button2SelfTalk;

            // Reset the index and continue with the new dialogues
            currentIndex = 0;

            // Hide the button again (if needed)
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);

            if (currentIndex < currentDialogue.Length)
            {
                // Start the new dialogue sequence
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }

            UpdateDialogueAfterNo();
        }

        void UpdateDialogueAfterYes() 
        {
            if (currentIndex >= currentDialogue.Length)
            {
                // All dialogue finished, show button3
                button3.gameObject.SetActive(true);
            }
        }

        void UpdateDialogueAfterNo()
        {
            if(currentIndex >= currentDialogue.Length)
            {
                button1.gameObject.SetActive(true);
                button2.gameObject.SetActive(true);
            }
        }

        //switch to holding letter image
        void switchImageClick()
        {
            if (officeWorkingImage != null)
                officeWorkingImage.gameObject.SetActive(false);

            if (quitJobLetterImage != null)
                quitJobLetterImage.gameObject.SetActive(true);

            button3.gameObject.SetActive(false);

            currentDialogue = continueSelfTalk;

            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                // Start the new dialogue sequence
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }

        }

        void GoToNextScene()
        {
            // Replace "NextSceneName" with the actual name of your next scene
            SceneManager.LoadScene(3);
        }
    }
}
