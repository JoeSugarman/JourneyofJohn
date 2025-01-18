using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JapanVn3V2 : MonoBehaviour
{
    DialogueSystem ds;
    TextArchitect architect;

    //button switching
    public UnityEngine.UI.Button Senbei;
    public UnityEngine.UI.Button Mochi;
    public UnityEngine.UI.Button Umeboshi;
    public UnityEngine.UI.Button JPVN3OneYes;
    public UnityEngine.UI.Button JPVN3OneNo;
    public UnityEngine.UI.Button JPVN3OneContinue;

    //turn off dialogue box
    public UnityEngine.UI.Image dialogueBox;
    public GameObject dialogueBoxText;

    //image switching
    public UnityEngine.UI.Image teleMount;
    public UnityEngine.UI.Image closeupmount;

    public UnityEngine.UI.Image mochi;
    public UnityEngine.UI.Image ume;
    public UnityEngine.UI.Image kata;

    //character switching
    public UnityEngine.UI.Image smalldisciple;
    public UnityEngine.UI.Image smalljohn;
    public UnityEngine.UI.Image bigdisciple;
    public UnityEngine.UI.Image bigjohn;
    public UnityEngine.UI.Image bigjohnNew;

    //dialogue tag
    public GameObject johnNameTagInVN3one;
    public GameObject discipleNameTagInVN3one;

    private string[] currentDialogue;
    bool dialogueFinished = false;

    //Disciple first dialogue
    string[] discipleFirstSay = new string[]
    {
        "Ohhhh!!! You are finally here."

    };

    string[] discipleFirstSay2 = new string[]
    {
        "You haven't died yet",
        "Do u need to take some rest?"
    };

    string[] johnFirstSay = new string[]
    {
        "Yes sure, please.",
        "I need to take rest.",
        "I am so tired.",
        "And I'm so hungry now xx"
    };

    //load related picture at the same time
    string[] discipleSecondSayOne = new string[]
    {
        "Do u want Katayaki Senbei?"
    };

    string[] discipleSecondSayTwo = new string[]
    {
        "Or Umeboshi?"
    };

    string[] discipleSecondSayThree = new string[]
    {
        "Or Mochi?"
    };

    //----------reply option----------------
    string[] johnSecondSaySenbei = new string[]
    {
        "Hummm, I want Senbei.",
        "I feel like I'm a ninja now."
    };

    string[] johnSecondSayUmeboshi = new string[]
    {
        "Hummm, I want Umeboshi.",
        "Coz I feel dizzy now."
    };

    string[] johnSecondSayMochi = new string[]
    {
        "Hummm, I want mochi.",
        "I'm very low blood sugar now."
    };
    //---------------------------------------

    string[] discipleThirdSay = new string[]
    {
        "Here you are, John.",
        "Enjoy your food."
    };

    string[] johnThirdSay = new string[]
    {
        "Thank you, disciple.",
        "BTW, how can we go down the mountain, we have walked a day already.",
        "The sky is getting dark, and we don't have tent, we need to arrive the forest as soon as possible."
    };

    string[] discipleFourthSay = new string[]
    {
        "Don't worry, John.",
        "I have a plan, I learnt some ninjutsu in the shrine.",
        "I can be your ski board",
        "Do u trust me?"
    };

    string[] johnFourthSay = new string[]
    {
        "What are you talking about?",
        "You mean I can use you as a ski board?"
    };

    string[] discipleFifthSay = new string[]
    {
        "Yes, John.",
        "I can be your ski board.",
        "I can use my ninjutsu to make you slide down the mountain.",
        "Do u trust me?"
    };

    string[] finalYes = new string[]
    {
        "All right!! Let's gooooooo"
    };

    string[] finalNo = new string[]
    {
        "Okay, then I'm gonna wait you there."
    };

    // Start is called before the first frame update
    void Start()
    {
        ds = DialogueSystem.instance;
        architect = new TextArchitect(ds.dialogueContainer.dialogueText);
        architect.buildMethod = TextArchitect.BuildMethod.typewriter;
        architect.speed = 0.5f;

        //assign first dialogue
        currentDialogue = discipleFirstSay;

        //add listerner to button
        Senbei.onClick.AddListener(SenbeiButton);
        Mochi.onClick.AddListener(MochiButton);
        Umeboshi.onClick.AddListener(UmeboshiButton);
        JPVN3OneYes.onClick.AddListener(FinalYes);
        JPVN3OneNo.onClick.AddListener(FinalNo);
        JPVN3OneContinue.onClick.AddListener(GoToNextScene);

        //deactivate objects
        closeupmount.gameObject.SetActive(false);
        bigdisciple.gameObject.SetActive(false);
        bigjohn.gameObject.SetActive(false);
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

                    if (currentDialogue == discipleFirstSay && dialogueFinished)
                        DiscipleFirstSay();
                    else if (currentDialogue == discipleFirstSay2 && dialogueFinished)
                        JohnFirstSay();
                    else if (currentDialogue == johnFirstSay && dialogueFinished)
                        DiscipleSecondSayOne();
                    else if (currentDialogue == discipleSecondSayOne && dialogueFinished)
                        DiscipleSecondSayTwo();
                    else if (currentDialogue == discipleSecondSayTwo && dialogueFinished)
                        DiscipleSecondSayThree();
                    else if (currentDialogue == discipleSecondSayThree && dialogueFinished)
                    {
                        Senbei.gameObject.SetActive(true);
                        Mochi.gameObject.SetActive(true);
                        Umeboshi.gameObject.SetActive(true);
                    }
                    else if ((currentDialogue == johnSecondSayMochi && dialogueFinished) || (currentDialogue == johnSecondSaySenbei && dialogueFinished) || (currentDialogue == johnSecondSayUmeboshi && dialogueFinished))
                        DiscipleThirdSay();
                    else if (currentDialogue == discipleThirdSay && dialogueFinished)
                        JohnThirdSay();
                    else if (currentDialogue == johnThirdSay && dialogueFinished)
                        DiscipleFourthSay();
                    else if (currentDialogue == discipleFourthSay && dialogueFinished)
                        JohnFourthSay();
                    else if (currentDialogue == johnFourthSay && dialogueFinished)
                        DiscipleFifthSay();
                    else if (currentDialogue == discipleFifthSay && dialogueFinished)
                    {
                        JPVN3OneYes.gameObject.SetActive(true);
                        JPVN3OneNo.gameObject.SetActive(true);
                    }
                    else if ((currentDialogue == finalYes && dialogueFinished) || (currentDialogue == finalNo && dialogueFinished))
                        showContinueButton();
                }
            }
        }
        levelToUnlock = chooseScene;
    }

    void DiscipleFirstSay()
    {
        dialogueFinished = false;

        //turnoff and on objects
        smalldisciple.gameObject.SetActive(false);
        bigjohn.gameObject.SetActive(true);
        smalljohn.gameObject.SetActive(false);
        bigdisciple.gameObject.SetActive(true);
        teleMount.gameObject.SetActive(false);
        closeupmount.gameObject.SetActive(true);

        currentDialogue = discipleFirstSay2;
        currentIndex = 0;

        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnFirstSay()
    {
        dialogueFinished = false;

        //change name tag
        discipleNameTagInVN3one.SetActive(false);
        johnNameTagInVN3one.SetActive(true);

        //change image
        bigjohn.gameObject.SetActive(false);
        bigjohnNew.gameObject.SetActive(true);

        currentDialogue = johnFirstSay;
        currentIndex = 0;

        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleSecondSayOne()
    {
        dialogueFinished = false;

        //turnoff and on objects
        discipleNameTagInVN3one.SetActive(true);
        johnNameTagInVN3one.SetActive(false);

        kata.gameObject.SetActive(true);

        currentDialogue = discipleSecondSayOne;

        currentIndex = 0;

        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleSecondSayTwo()
    {
        dialogueFinished = false;

        kata.gameObject.SetActive(false);
        ume.gameObject.SetActive(true);

        currentDialogue = discipleSecondSayTwo;
        currentIndex = 0;

        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleSecondSayThree()
    {
        dialogueFinished = false;

        ume.gameObject.SetActive(false);
        mochi.gameObject.SetActive(true);

        currentDialogue = discipleSecondSayThree;
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
            Senbei.gameObject.SetActive(true);
            Mochi.gameObject.SetActive(true);
            Umeboshi.gameObject.SetActive(true);
        }
    }

    void SenbeiButton()
    {
        dialogueFinished = false;

        Senbei.gameObject.SetActive(false);
        Mochi.gameObject.SetActive(false);
        Umeboshi.gameObject.SetActive(false);
        mochi.gameObject.SetActive(false);

        discipleNameTagInVN3one.SetActive(false);
        johnNameTagInVN3one.SetActive(true);

        currentDialogue = johnSecondSaySenbei;
        currentIndex = 0;

        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void UmeboshiButton()
    {
        dialogueFinished = false;

        Senbei.gameObject.SetActive(false);
        Mochi.gameObject.SetActive(false);
        Umeboshi.gameObject.SetActive(false);
        mochi.gameObject.SetActive(false);

        discipleNameTagInVN3one.SetActive(false);
        johnNameTagInVN3one.SetActive(true);

        currentDialogue = johnSecondSayUmeboshi;
        currentIndex = 0;

        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void MochiButton()
    {
        dialogueFinished = false;
        Senbei.gameObject.SetActive(false);
        Mochi.gameObject.SetActive(false);
        Umeboshi.gameObject.SetActive(false);
        mochi.gameObject.SetActive(false);

        discipleNameTagInVN3one.SetActive(false);
        johnNameTagInVN3one.SetActive(true);

        currentDialogue = johnSecondSayMochi;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleThirdSay()
    {
        dialogueFinished = false;
        currentDialogue = discipleThirdSay;

        discipleNameTagInVN3one.SetActive(true);
        johnNameTagInVN3one.SetActive(false);

        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnThirdSay()
    {
        dialogueFinished = false;
        currentDialogue = johnThirdSay;
        discipleNameTagInVN3one.SetActive(false);
        johnNameTagInVN3one.SetActive(true);
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleFourthSay()
    {
        dialogueFinished = false;
        currentDialogue = discipleFourthSay;
        discipleNameTagInVN3one.SetActive(true);
        johnNameTagInVN3one.SetActive(false);
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnFourthSay()
    {
        dialogueFinished = false;
        currentDialogue = johnFourthSay;
        discipleNameTagInVN3one.SetActive(false);
        johnNameTagInVN3one.SetActive(true);
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleFifthSay()
    {
        dialogueFinished = false;
        currentDialogue = discipleFifthSay;
        discipleNameTagInVN3one.SetActive(true);
        johnNameTagInVN3one.SetActive(false);
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }

        showbutton2();
    }

    void showbutton2()
    {
        if (currentIndex >= currentDialogue.Length)
        {
            JPVN3OneYes.gameObject.SetActive(true);
            JPVN3OneNo.gameObject.SetActive(true);
        }
    }

    private int chooseScene;
    void FinalYes()
    {
        chooseScene = 9;

        dialogueFinished = false;
        currentDialogue = finalYes;
        discipleNameTagInVN3one.SetActive(false);
        johnNameTagInVN3one.SetActive(true);

        JPVN3OneYes.gameObject.SetActive(false);
        JPVN3OneNo.gameObject.SetActive(false);

        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
        showContinueButton();

        StartCoroutine(RotateBigDisciple());

    }

    IEnumerator RotateBigDisciple() 
    {
        while (!dialogueFinished)
            yield return null;

        float duration = 0.5f;
        float elapsed = 0f;
        Quaternion initialRotation = bigdisciple.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, 90f);

        Vector3 initialPosition = bigjohnNew.rectTransform.localPosition;
        Vector3 targetPosition = initialPosition + new Vector3(230, 20, 0);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            bigdisciple.rectTransform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsed / duration);
            
            bigjohnNew.rectTransform.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsed / duration);

            yield return null;
        }

        bigdisciple.rectTransform.rotation = targetRotation;
        bigjohn.rectTransform.localPosition = targetPosition;
        dialogueBox.gameObject.SetActive(false);
        dialogueBoxText.SetActive(false);
    }



    void FinalNo()
    {
        chooseScene = 10;

        JPVN3OneYes.gameObject.SetActive(false);
        JPVN3OneNo.gameObject.SetActive(false);

        dialogueFinished = false;
        currentDialogue = finalNo;
        discipleNameTagInVN3one.SetActive(false);
        johnNameTagInVN3one.SetActive(true);
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
            JPVN3OneContinue.gameObject.SetActive(true);
        }
    }

    public int levelToUnlock;
    void GoToNextScene()
    {
        if (MainMenuGameManager.Instance != null)
        {
            if (levelToUnlock > MainMenuGameManager.Instance.currentLevel)
            {
                MainMenuGameManager.Instance.currentLevel = levelToUnlock;
                MainMenuGameManager.Instance.SaveProgress();
            }
        }

        SceneManager.LoadScene(chooseScene);
    }
}
