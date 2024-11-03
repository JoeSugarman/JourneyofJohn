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
        public UnityEngine.UI.Button VN1Yes1;
        public UnityEngine.UI.Button VN1No1;
        public UnityEngine.UI.Button VN1Continue2;

        //image switching
        public UnityEngine.UI.Image shrineFrontDoor;
        public UnityEngine.UI.Image shrineInside;
        public UnityEngine.UI.Image standingConversation;

        //dialogue
        public GameObject johnNameTag;
        public GameObject nonJohnNameTag;

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

        //priest first dialogue
        string[] interviewWithJohn = new string[]
        {
            "Hey young man, what are you doing?",
            "Today isn't a holiday, don't you need to go to work?",
            "Hey open your eyes, I'm here. The voice is from me, not the god!"
        };

        //should john open eyes
        string[] openEyes = new string[]
        {
            "Should I open my eyes?",
            "Maybe this is a test from god"
        };

        //should john open eyes: yes
        string[] openEyesYes = new string[]
        {
            "A? Is someone talking to me?",
            "The sound feels close to my ear."
        };

        //should john open eyes: no
        string[] openEyesNo = new string[]
        {
            "Hey!!!",
            "I'm talking to you!!!",
            "Wake up!!!"
        };

        //hummm should I
        string[] shouldI = new string[]
        {
            "Hmmmmmm..."
        };

        //--------------new stage----------------
        //asking from the old
        string[] askingForDetail = new string[]
        {
            "Why would you quit your job?"
        };

        //answer from john
        string[] answerFromJohn = new string[]
        {
            "I don't want to be a robot anymore.",
            "In the office day, I kept doing the same thing but that is not what I want to do for my whole life.",
            "It is stable, but not fun.",
            "Soooooo, I quit my job and I hope I can visit as most as places in my remaining life."
        };

        //reply from the old
        string[] replyFromOld = new string[]
        {
            "I see...",
            "So you think you can find an answer here?",
            "That sounds romantic",
            "I mean, UNREALISTIC",
            "But I can't stop you from doing that.",
            "Maybe I can help you",
            "But you have to help me to do something first"
        };

        //question from john
        string[] whatIsIt = new string[]
        {
            "What is it?",
            "I would try my best if I think I am able to do or help with.",
            "But I can't promise you that I can do it."
        };

        //reply from the old
        string[] giveChoice = new string[]
        {
            "You cannot know it before you promise me.",
            "This is the rule.",
            "You have two choices now, either promise me you can help, and then I would help you to go to another place.",
            "Or you could say no, but of course you can't get any help from me if you choose that.",
            "So, what is your choice?"
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
            VN1Yes1.onClick.AddListener(OpenEyeYes);
            VN1No1.onClick.AddListener(OpenEyeNo);
            VN1Continue2.onClick.AddListener(EnterConversationBetweenJohnAndOldman);

            //deactivate all objects
            if (shrineInside != null)
                shrineInside.gameObject.SetActive(false);
            if (nonJohnNameTag != null)
                nonJohnNameTag.gameObject.SetActive(false);
            if (VN1Yes1 != null)
                VN1Yes1.gameObject.SetActive(false);
            if (VN1No1 != null)
                VN1No1.gameObject.SetActive(false);
            if (VN1Continue2 != null)
                VN1Continue2.gameObject.SetActive(false);
            if (standingConversation != null)
                standingConversation.gameObject.SetActive(false);
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
                        dialogueFinished = true;

                        if (currentDialogue == frontDoorDialogue)
                        {
                            //activate the button
                            VN1Continue1.gameObject.SetActive(true);
                        }
                        else if (currentDialogue == prayInFrontOFShrine && dialogueFinished)
                        {
                            priestFirstTalk();
                        }
                        else if (currentDialogue == interviewWithJohn && dialogueFinished)
                        {
                            shouldIOpenEye();
                        }
                        else if (currentDialogue == openEyes && dialogueFinished)
                        {
                            VN1Yes1.gameObject.SetActive(true);
                            VN1No1.gameObject.SetActive(true);
                        }
                        else if (currentDialogue == openEyesNo && dialogueFinished)
                        {
                            shouldIOpen();
                        }
                        else if (currentDialogue == openEyesYes)
                        {
                            VN1Continue2.gameObject.SetActive(true);
                        }
                        else if (currentDialogue == askingForDetail && dialogueFinished)
                        {
                            johnReply();
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

        void priestFirstTalk()
        {
            dialogueFinished = false;

            //turn off john's dialogue
            johnNameTag.gameObject.SetActive(false);

            //turn on non-john's dialogue
            nonJohnNameTag.gameObject.SetActive(true);

            //load new dialogue
            currentDialogue = interviewWithJohn;
            currentIndex = 0;


            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

        void shouldIOpenEye()
        {
            dialogueFinished = false;

            //turn off non-john's dialogue
            nonJohnNameTag.gameObject.SetActive(false);

            //turn on john's dialogue
            johnNameTag.gameObject.SetActive(true);

            //load new dialogue
            currentDialogue = openEyes;
            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }

            ChooseOpenEye();
        }

        void ChooseOpenEye() 
        {
            if(currentIndex >= currentDialogue.Length)
            {
                VN1Yes1.gameObject.SetActive(true);
                VN1No1.gameObject.SetActive(true);
            }
        } 

        void OpenEyeYes()
        {
            dialogueFinished = false;

            currentDialogue = openEyesYes;

            currentIndex = 0;

            VN1Yes1.gameObject.SetActive(false);
            VN1No1.gameObject.SetActive(false);

            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

        void OpenEyeNo()
        {
            dialogueFinished = false;

            //turn off john's dialogue
            johnNameTag.gameObject.SetActive(false);

            //turn on non-john's dialogue
            nonJohnNameTag.gameObject.SetActive(true);

            currentDialogue = openEyesNo;

            currentIndex = 0;

            VN1Yes1.gameObject.SetActive(false);
            VN1No1.gameObject.SetActive(false);

            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            } 
        }

        void shouldIOpen()
        {
            dialogueFinished = false;

            //turn off non-john's dialogue
            nonJohnNameTag.gameObject.SetActive(false);

            //turn on john's dialogue
            johnNameTag.gameObject.SetActive(true);

            //load new dialogue
            currentDialogue = shouldI;
            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }

            ChooseOpenEye();
        }

        void EnterConversationBetweenJohnAndOldman()
        {
            //change background
            shrineInside.gameObject.SetActive(false);
            standingConversation.gameObject.SetActive(true);

            //change the name tag
            johnNameTag.gameObject.SetActive(false);
            nonJohnNameTag.gameObject.SetActive(true);

            //turn of continue button
            VN1Continue2.gameObject.SetActive(false);

            //load new dialogue
            currentDialogue = askingForDetail;
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

        void johnReply()
        {

        }

    }
}
