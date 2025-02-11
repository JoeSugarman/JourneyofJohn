using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace TESTING
{
    public class JapanVN2 : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;
        private int chooseScene;

        //button switching
        public UnityEngine.UI.Button VN2Yes1;
        public UnityEngine.UI.Button VN2No1;
        public UnityEngine.UI.Button VN2Continue;


        //image switching
        public UnityEngine.UI.Image pureblack;
        public UnityEngine.UI.Image chamber;
        public UnityEngine.UI.Image HowToPlay;

        //character switching
        public UnityEngine.UI.Image VN2john;
        public UnityEngine.UI.Image VN2disciple;
        public UnityEngine.UI.Image VN2priest;

        //dialogue
        public GameObject johnNameTagInVN2;
        public GameObject discipleTagInVN2;
        public GameObject priestNameTagInVN2;
        public GameObject theOldThickDoor;

        private string[] currentDialogue;
        bool dialogueFinished = false;

        //big thick old door open sound
        string[] doorOpenSound = new string[]
        {
            "Rrrrraaaawwwwwwkkkkk..."
        };

        //priest first dialogue
        string[] PriestIntroduceTheChamber = new string[]
        {
            "Do you see these ancient artefacts?",
            "They are beautiful, aren't they?",
            "They become charcoal now. But in around 500 years ago, they are some very beautiful ancient artefacts.",
            "Ema, Komainu, Shaku, Wooden Drums and some statues.",
            "But after a big fire, all of them are destroyed.",
            "We want to repair them but we cannot find the suitable wood nearby."
        };

        //john first dialogue
        string[] Question = new string[]
        {
            "What kind of wood do we need to use to repair it?"
        };

        //priest second dialogue
        string[] PriestAnswer = new string[]
        {
            "We need to use the wood from the sacred tree, the tree that has been blessed by the gods.",
            "After you walk accross the mountain, you will see a forest.",
            "In that forest, there is a kind of tree called Kokutan wood.",
            "This kind of tree is very rare. As I know, it only appears in that forest."
        };

        //john second dialogue
        string[] JohnQuestion = new string[]
        {
            "So...... You want me to help you to bring some Kokutan wood back to here.",
            "It is impossible. Even though I can arrive the forest, It is still very difficult to transport the logs back to the shrine."
        };

        //priest third dialogue
        string[] PriestReply = new string[]
        {
            "I know it is difficult. But I believe you can do it.",
            "Additionally, I will send a disciple to follow with you."
        };

        //disciple first dialogue
        string[] selfIntro = new string[]
        {
            "Hello, I am the disciple of the priest.",
            "I will help you to bring the Kokutan wood back to the shrine.",
            "Do you want me to follow you all the time or waiting you at the top of the mount?"
        };

        //john choice by button here

        //--------------------- new stage ---------------------
        //priest fourth dialogue
        string[] PriestFinal = new string[]
        {
            "Great!",
            "Here is the final thing",
            "In order to keep you safe, here is the book for you to learn some skills to protect yourself",
            "To use kame hameha, press comma on your keyboard.",
            "So!!! Remember to bring a keyboard with you."
        };

        //john final dialogue
        string[] JohnFinal = new string[]
        {
            "Huh?",
            "Hummm... A keyboard?",
            "Okayyy, I will remember that.",
            "And I will bring the Kokutan wood back to the shrine."
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.typewriter;
            architect.speed = 0.5f;

            //assign first dialogue
            currentDialogue = doorOpenSound;

            //add listerner to button
            VN2Yes1.onClick.AddListener(GowithHim);
            VN2No1.onClick.AddListener(GowithoutHim);
            VN2Continue.onClick.AddListener(goToNextScene);

            //deactivate objects
            if (chamber != null)
                chamber.gameObject.SetActive(false);
            if (johnNameTagInVN2 != null)
                johnNameTagInVN2.SetActive(false);
            if (discipleTagInVN2 != null)
                discipleTagInVN2.SetActive(false);
            if (priestNameTagInVN2 != null)
                priestNameTagInVN2.SetActive(false);
            if (VN2No1 != null)
                VN2No1.gameObject.SetActive(false);
            if (VN2Yes1 != null)
                VN2Yes1.gameObject.SetActive(false);
            if (HowToPlay != null)
                HowToPlay.gameObject.SetActive(false);
            if (VN2Continue != null)
                VN2Continue.gameObject.SetActive(false);

            
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
                    {
                        architect.hurryUp = true;
                    }
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

                        if (currentDialogue == doorOpenSound)
                            enterChamber();
                        else if (currentDialogue == PriestIntroduceTheChamber && dialogueFinished)
                            johnQuestion();
                        else if (currentDialogue == Question && dialogueFinished)
                            priestAnswer();
                        else if (currentDialogue == PriestAnswer && dialogueFinished)
                            johnSecondQuestion();
                        else if (currentDialogue == JohnQuestion && dialogueFinished)
                            priestReply();
                        else if (currentDialogue == PriestReply && dialogueFinished)
                            SelfIntro();
                        else if (currentDialogue == selfIntro && dialogueFinished)
                        {
                            VN2No1.gameObject.SetActive(true);
                            VN2Yes1.gameObject.SetActive(true);
                        }
                        else if (currentDialogue == PriestFinal && dialogueFinished)
                            johnFinal();
                        else if (currentDialogue == JohnFinal && dialogueFinished)
                            showContinueButton();

                    }

                }

            }
            levelToUnlock = chooseScene;
        }
        void enterChamber()
        {
            dialogueFinished = false;

            //change background
            pureblack.gameObject.SetActive(false);
            chamber.gameObject.SetActive(true);

            //turn on character
            VN2john.gameObject.SetActive(true);
            VN2priest.gameObject.SetActive(true);

            //change name tag
            theOldThickDoor.SetActive(false);
            johnNameTagInVN2.SetActive(false);
            discipleTagInVN2.SetActive(false);
            priestNameTagInVN2.SetActive(true);

            //load new dialogue
            currentDialogue = PriestIntroduceTheChamber;
            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }

        }

        void johnQuestion()
        {
            dialogueFinished = false;

            //change name tag
            johnNameTagInVN2.SetActive(true);
            discipleTagInVN2.SetActive(false);
            priestNameTagInVN2.SetActive(false);
            theOldThickDoor.SetActive(false);

            //load new dialogue
            currentDialogue = Question;
            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }

        }

        void priestAnswer()
        {
            dialogueFinished = false;

            //change name tag
            johnNameTagInVN2.SetActive(false);
            discipleTagInVN2.SetActive(false);
            priestNameTagInVN2.SetActive(true);

            //load new dialogue
            currentDialogue = PriestAnswer;
            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

        void johnSecondQuestion()
        {
            dialogueFinished = false;

            //change name tag
            johnNameTagInVN2.SetActive(true);
            discipleTagInVN2.SetActive(false);
            priestNameTagInVN2.SetActive(false);

            //load new dialogue
            currentDialogue = JohnQuestion;
            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

        void priestReply()
        {
            dialogueFinished = false;
            //change name tag
            johnNameTagInVN2.SetActive(false);
            discipleTagInVN2.SetActive(true);
            priestNameTagInVN2.SetActive(false);
            //load new dialogue
            currentDialogue = PriestReply;
            currentIndex = 0;
            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

        void SelfIntro()
        {
            dialogueFinished = false;
            //change name tag
            johnNameTagInVN2.SetActive(false);
            discipleTagInVN2.SetActive(true);
            priestNameTagInVN2.SetActive(false);

            VN2disciple.gameObject.SetActive(true);

            //load new dialogue
            currentDialogue = selfIntro;
            currentIndex = 0;
            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }

            showButton();
        }

        void showButton()
        {
            if (currentIndex >= currentDialogue.Length)
            {
                VN2No1.gameObject.SetActive(true);
                VN2Yes1.gameObject.SetActive(true);
            }

        }

        void GowithHim()
        {
            chooseScene = 5;

            dialogueFinished = false;
            //change name tag
            johnNameTagInVN2.SetActive(false);
            discipleTagInVN2.SetActive(false);
            priestNameTagInVN2.SetActive(true);

            //turn off button
            VN2No1.gameObject.SetActive(false);
            VN2Yes1.gameObject.SetActive(false);

            VN2disciple.gameObject.SetActive(false);
            VN2john.gameObject.SetActive(false);
            VN2priest.gameObject.SetActive(false);

            //turn on a new image
            HowToPlay.gameObject.SetActive(true);


            //load new dialogue
            currentDialogue = PriestFinal;
            currentIndex = 0;
            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

        void GowithoutHim()
        {
            chooseScene = 6;

            dialogueFinished = false;
            //change name tag
            johnNameTagInVN2.SetActive(false);
            discipleTagInVN2.SetActive(false);
            priestNameTagInVN2.SetActive(true);

            //turn off button
            VN2No1.gameObject.SetActive(false);
            VN2Yes1.gameObject.SetActive(false);

            VN2disciple.gameObject.SetActive(false);
            VN2john.gameObject.SetActive(false);
            VN2priest.gameObject.SetActive(false);

            //turn on a new image
            HowToPlay.gameObject.SetActive(true);

            //load new dialogue
            currentDialogue = PriestFinal;
            currentIndex = 0;
            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }
        }

        void johnFinal()
        {
            dialogueFinished = false;
            //change name tag
            johnNameTagInVN2.SetActive(true);
            discipleTagInVN2.SetActive(false);
            priestNameTagInVN2.SetActive(false);

            //turn of image
            HowToPlay.gameObject.SetActive(false);
            VN2john.gameObject.SetActive(true);
            VN2priest.gameObject.SetActive(true);

            currentDialogue = JohnFinal;
            currentIndex = 0;

            if (currentIndex < currentDialogue.Length)
            {
                architect.Build(currentDialogue[currentIndex]);
                currentIndex++;
            }

            showContinueButton();
        }

        void showContinueButton()
        {
            if (currentIndex >= currentDialogue.Length)
            {
                VN2Continue.gameObject.SetActive(true);
            }

        }

        public int levelToUnlock;
        void goToNextScene()
        {
            //if (MainMenuManager.Instance != null)
            //{
            //    if (MainMenuManager.Instance != null)
            //    {
            //        if (levelToUnlock == 5)
            //            MainMenuManager.Instance.isGS2Point1Unlocked = true;
            //        else if (levelToUnlock == 6)
            //            MainMenuManager.Instance.isGS2Point2Unlocked = true;
            //    }
            //}

            //SceneManager.LoadScene(chooseScene);
            StartCoroutine(FadeOutAndLoadScene());
        }

        [SerializeField] private CanvasGroup transitionPanel;

        private IEnumerator FadeOutAndLoadScene()
        {
            float duration = 1.5f;
            float time = 0f;
            float startAlpha = transitionPanel.alpha;
            float targetAlpha = 1f;

            while (time < duration)
            {
                transitionPanel.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
                time += Time.deltaTime;
                yield return null;
            }

            if (MainMenuManager.Instance != null)
            {
                if (MainMenuManager.Instance != null)
                {
                    if (levelToUnlock == 5)
                        MainMenuManager.Instance.isGS2Point1Unlocked = true;
                    else if (levelToUnlock == 6)
                        MainMenuManager.Instance.isGS2Point2Unlocked = true;
                }
            }

            SceneManager.LoadScene(chooseScene);
        }
    }
}