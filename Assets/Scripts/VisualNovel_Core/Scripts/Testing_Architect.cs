using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;

        TextArchitect architect;

        //buttons for first interaction yes and no
        public UnityEngine.UI.Button button1;
        public UnityEngine.UI.Button button2;
        public UnityEngine.UI.Button button3;
        public UnityEngine.UI.Button ramen;
        public UnityEngine.UI.Button sushi;
        public UnityEngine.UI.Button newResterant;
        public UnityEngine.UI.Button continue2;
        public UnityEngine.UI.Button continue3;
        public UnityEngine.UI.Button BackToHome;
        public UnityEngine.UI.Button BackToWork;
        public UnityEngine.UI.Button continue4;

        //images swithching
        public UnityEngine.UI.Image officeWorkingImage;
        public UnityEngine.UI.Image quitJobLetterImage;
        public UnityEngine.UI.Image leavingLetter;
        public UnityEngine.UI.Image atm;

        private string[] currentDialogue;
        bool dialogueFinished = false;


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
            "This probably the best moment in my life ;)",
            "What should I eat later?",
            "Ramen? Shushi? What if go to the new restaurant near the train station?"
        };

        //great choice self talk
        string[] greatChoice = new string[]
        {
            "Great Choice!",
            "You really know what I want. Haha"
        };

        //office selftalk
        string[] officeselftalk = new string[]
        {
            "It should be ok to just leaving this letter on my desk.",
            "See you my desk, see you my boss :>"
        };

        //Oh no, I have no money selftalk
        string[] noMoney = new string[]
        {
            "OH NO!!!!!!!!!!!!!",
            "Why there is no money in my bank account?",
            "How can I travel without money?!?!",
            "Shxt! No jobs, no money, who am I now? I'm nothing but a middle age bachelor... "
        };

        //backtohome selftalk
        string[] backToHome = new string[]
        {
            "Yea, I should go back to my home and think about my life...",
            "Wait no. I should go back to my home and take a nap",
            "What should I do next?",
            "I have infinite time without a job, would this question be a question to me?",
            "It should be 20 years that I didn't sleep more than 6 hours everyday.",
            "So, I'm not going to take a nap, I'm going to take a 'coma'. "
        };

        //backtowork selftalk
        string[] backtowork = new string[]
        {
            "Back to work? My boss would probably kill me.",
            "Can I go back to my previous position if I'm back to office now?",
            "Probably not, I should go back to my home and take a nap.",
            "What should I do next?",
            "This is not the most urgent question for me, even though my bank account has zero money left.",
            "Life is more important"
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
            ramen.onClick.AddListener(ramenSuShiRestClick);
            sushi.onClick.AddListener(ramenSuShiRestClick);
            newResterant.onClick.AddListener(ramenSuShiRestClick);
            continue2.onClick.AddListener(SwitchOfficeImage);
            continue3.onClick.AddListener(SwitchATMImage);
            BackToHome.onClick.AddListener(BackToHomeClick);
            BackToWork.onClick.AddListener(BackToWorkClick);
            continue4.onClick.AddListener(GoToNextScene);

            //deactivate all images
            if (quitJobLetterImage != null)
                quitJobLetterImage.gameObject.SetActive(false);
            if (leavingLetter != null)
                leavingLetter.gameObject.SetActive(false);
            if (atm != null)
                atm.gameObject.SetActive(false);
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
                        else if (currentDialogue == continueSelfTalk)
                        {
                            ramen.gameObject.SetActive(true);
                            sushi.gameObject.SetActive(true);
                            newResterant.gameObject.SetActive(true);
                        }
                        else if (currentDialogue == greatChoice)
                        {
                            continue2.gameObject.SetActive(true);
                        }
                        else if (currentDialogue == officeselftalk)
                        {
                            continue3.gameObject.SetActive(true);
                        }
                        else if (currentDialogue == noMoney)
                        {
                            BackToHome.gameObject.SetActive(true);
                            BackToWork.gameObject.SetActive(true);
                        }
                        else if (currentDialogue == backToHome || currentDialogue == backtowork)
                        {
                            continue4.gameObject.SetActive(true); // Transition to the next scene
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

            if(currentIndex >= currentDialogue.Length)
            {
                ramen.gameObject.SetActive(true);
                sushi.gameObject.SetActive(true);
                newResterant.gameObject.SetActive(true);
            }

        }

        void ramenSuShiRestClick() 
        {
            // Load the new string array for dialogues
            currentDialogue = greatChoice;

            // Reset the index and continue with the new dialogues
            currentIndex = 0;

            ramen.gameObject.SetActive(false);
            sushi.gameObject.SetActive(false);
            newResterant.gameObject.SetActive(false);

            // Start the new dialogue sequence
            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

        void UpdateButtonForGoToOffice()
        {
            if (currentIndex >= currentDialogue.Length)
            {
                // All dialogue finished, show continue2
                continue2.gameObject.SetActive(true);
            }
        }

        void SwitchOfficeImage()
        {
            if (officeWorkingImage != null)
                officeWorkingImage.gameObject.SetActive(false);

            if (quitJobLetterImage != null)
                quitJobLetterImage.gameObject.SetActive(false);

            if (leavingLetter != null)
                leavingLetter.gameObject.SetActive(true);

            continue2.gameObject.SetActive(false);

            
            
            currentDialogue = officeselftalk;

            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                // Start the new dialogue sequence
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

        void UpdateButtonForGoToATM()
        {
            if (currentIndex >= currentDialogue.Length)
            {
                // All dialogue finished, show button3
                continue3.gameObject.SetActive(true);
            }
        }

        void SwitchATMImage()
        {
            if (leavingLetter != null)
                leavingLetter.gameObject.SetActive(false);
            if (atm != null)
                atm.gameObject.SetActive(true);

            continue3.gameObject.SetActive(false);

            currentDialogue = noMoney;
            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                // Start the new dialogue sequence
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

        void BackToHomeClick()
        {
            BackToHome.gameObject.SetActive(false);
            BackToWork.gameObject.SetActive(false);

            currentDialogue = backToHome;
            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                // Start the new dialogue sequence
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }else
            {
                dialogueFinished = true;
            }
            

        }

        void BackToWorkClick()
        {
            BackToHome.gameObject.SetActive(false);
            BackToWork.gameObject.SetActive(false);

            currentDialogue = backtowork;
            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                // Start the new dialogue sequence
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
            else
            {
                dialogueFinished = true;
            }



        }

        
        public int levelToUnlock=2; // The level to unlock after clicking this button

    void GoToNextScene()
    {
        //MainMenuManager mainMenuManager = FindObjectOfType<MainMenuManager>();
        if (MainMenuManager.Instance != null)
        {
            MainMenuManager.Instance.isVS1Unlocked = true;
        }

        // load JPVN1
        SceneManager.LoadScene(2);
    }
    }

