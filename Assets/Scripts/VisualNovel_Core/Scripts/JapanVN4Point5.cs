using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JapanVN4Point5 : MonoBehaviour
{
    DialogueSystem ds;
    TextArchitect architect;

    private string[] currentDialogue;
    bool dialogueFinished = false;

    //dialogue name tag
    public GameObject johnNameTagVN4point5;
    public GameObject discipleNameTagVN4point5;

    //image and video
    public UnityEngine.UI.Image woodlogcart;
    public GameObject videoEating;
    public UnityEngine.UI.Image dieJohn;
    public UnityEngine.UI.Image aliveJohn;


    //button
    public UnityEngine.UI.Button JPVN4point5Continue;

    //john first dialogue
    string[] johnFirstDialogue = new string[]
    {
        "Hey master, do we have enough woods now?"
    };

    string[] discipleFirstSay = new string[]
    {
        "Let me see...",
        "Hummm, I think we need more.",
        "We have too many artefacts that need to be repaired.",
        "If we don't prepare enough wood, we need to come back here again."
    };

    string[] johnSecondDialogue = new string[]
    {
        "I see...",
        "But master, when we are chopping trees, I also need to kill slimes.",
        "I felt hungry again..."
    };

    string[] discipleSecondSay = new string[]
    {
        "Well well well",
        "Cityboy is too weak that get hungry easily.",
        "That's why you need to do more execrise when you have spare time.",
        "If you only sitting in front of the computer for all day, this is the result."
    };

    string[] johnThirdDialogue = new string[]
    {
        "I know...",
        "But master, I am not a cityboy.",
        "I am a game developer.",
        "I need to sit in front of the computer for all day to make games.",
        "Anddd, do you have any food now?"
    };

    string[] discipleThirdSay = new string[]
    {
        "Sigh...",
        "I still have some riceballs.",
        "Do you want some?"
    };

    string[] johnFourthDialogue = new string[]
    {
        "Yes, please.",
        "I am so hungry now."
    };

    string[] discipleFourthSay = new string[]
    {
        "Here you go.",
        "This is the last time."
    };

    //----play eating riceballs animation
    string[] nyumnyum = new string[]
    {
        "Nyum Nyum Nyum Nyum Nyum",
        "Nyum Nyum Nyum Nyum Nyum......"
    };

    string[] disciplefifthSay = new string[]
    {
        "Have you finished the riceballs?",
        "We don't have much time",
        "Go to chop more trees now!!!"
    };

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        ds = DialogueSystem.instance;
        architect = new TextArchitect(ds.dialogueContainer.dialogueText);
        architect.buildMethod = TextArchitect.BuildMethod.typewriter;
        architect.speed = 0.5f;

        //assign first dialogue
        currentDialogue = johnFirstDialogue;

        //button
        JPVN4point5Continue.onClick.AddListener(GoToNextScene);
    }

    private int currentIndex = 0;

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
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

                        if(currentDialogue == johnFirstDialogue && dialogueFinished)
                            DiscipleFirstSay();
                        else if (currentDialogue == discipleFirstSay && dialogueFinished)
                        JohnSecondDialogue();
                    else if (currentDialogue == johnSecondDialogue && dialogueFinished)
                        DiscipleSecondSay();
                    else if (currentDialogue == discipleSecondSay && dialogueFinished)
                        JohnThirdDialogue();
                    else if (currentDialogue == johnThirdDialogue && dialogueFinished)
                        DiscipleThirdSay();
                    else if (currentDialogue == discipleThirdSay && dialogueFinished)
                        JohnFourthDialogue();
                    else if (currentDialogue == johnFourthDialogue && dialogueFinished)
                        DiscipleFourthSay();
                    else if (currentDialogue == discipleFourthSay && dialogueFinished)
                        NyumNyum();
                        else if (currentDialogue == nyumnyum && dialogueFinished)
                        DiscipleFifthSay();
                    else if (currentDialogue == disciplefifthSay && dialogueFinished)
                        showContinueButton();
                }
                }
            }
    }

    void DiscipleFirstSay() 
    {
        //change name tag
        johnNameTagVN4point5.SetActive(false);
        discipleNameTagVN4point5.SetActive(true);

        dialogueFinished = false;

        currentDialogue = discipleFirstSay;

        currentIndex = 0;

        if (currentIndex < currentDialogue.Length) 
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }

    }

    void JohnSecondDialogue()
    {
        //change name tag
        discipleNameTagVN4point5.SetActive(false);
        johnNameTagVN4point5.SetActive(true);

        dialogueFinished = false;
        currentDialogue = johnSecondDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleSecondSay()
    {
        //change name tag
        johnNameTagVN4point5.SetActive(false);
        discipleNameTagVN4point5.SetActive(true);

        dialogueFinished = false;
        currentDialogue = discipleSecondSay;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnThirdDialogue()
    {
        //change name tag
        discipleNameTagVN4point5.SetActive(false);
        johnNameTagVN4point5.SetActive(true);

        dialogueFinished = false;
        currentDialogue = johnThirdDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleThirdSay()
    {
        //change name tag
        johnNameTagVN4point5.SetActive(false);
        discipleNameTagVN4point5.SetActive(true);

        dialogueFinished = false;
        currentDialogue = discipleThirdSay;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnFourthDialogue()
    {
        //change name tag
        discipleNameTagVN4point5.SetActive(false);
        johnNameTagVN4point5.SetActive(true);

        dialogueFinished = false;
        currentDialogue = johnFourthDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleFourthSay()
    {
        //change name tag
        johnNameTagVN4point5.SetActive(false);
        discipleNameTagVN4point5.SetActive(true);

        dialogueFinished = false;
        currentDialogue = discipleFourthSay;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void NyumNyum()
    {
        //turn on eating video
        videoEating.SetActive(true);
        dieJohn.gameObject.SetActive(false);

        discipleNameTagVN4point5.SetActive(false);
        johnNameTagVN4point5.SetActive(true);

        dialogueFinished = false;
        currentDialogue = nyumnyum;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleFifthSay()
    {
        //change name tag
        johnNameTagVN4point5.SetActive(false);
        discipleNameTagVN4point5.SetActive(true);

        videoEating.SetActive(false);
        aliveJohn.gameObject.SetActive(true);

        dialogueFinished = false;
        currentDialogue = disciplefifthSay;
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
            JPVN4point5Continue.gameObject.SetActive(true);
        }
    }

    //public WoodChecker woodChecker;
    public int levelToUnlock = 15;

    void GoToNextScene()
    {
        //if (MainMenuManager.Instance != null)
        //{
        //    MainMenuManager.Instance.isGS4Unlocked = true;
        //}
        //SceneManager.LoadScene(15);
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
            MainMenuManager.Instance.isGS4Unlocked = true;
        }
        SceneManager.LoadScene(15);
    }

    }

