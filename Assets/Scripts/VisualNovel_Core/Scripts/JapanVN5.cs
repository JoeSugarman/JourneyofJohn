using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JapanVN5 : MonoBehaviour
{
    DialogueSystem ds;
    TextArchitect architect;

    private string[] currentDialogue;
    bool dialogueFinished = false;

    //dialogue name tag
    public GameObject johnNameTagVN5;
    public GameObject discipleNameTagVN5;

    //image and video
    public UnityEngine.UI.Image woodlogcart;
    public GameObject videoCharming;
    public UnityEngine.UI.Image dieJohn2;
    public UnityEngine.UI.Image aliveJohn2;

    //button
    public UnityEngine.UI.Button JPVN5Continue;


    string[] johnFirstDialogue = new string[]
    {
        "Hey master, do we have enough woods now?"
    };

    string[] discipleFirstSay = new string[]
    {
        "Let me see...",
        "1, 2, 3, 4, 5, 6, 7, 8, 9...",
        "Congratulation!!! We have enough logs now",
        "The next step is to bring all the logs back to the shrine.",
        "Do you think you can handle it?"
    };

    string[] johnSecondDialogue = new string[]
    {
        "Master...",
        "There are over 2 tons of wood, how can I pull the cart back to the shrine",
        "I even can't pull it on a flat horizontal ground.",
        "How can I pull it across the mountain?"
    };

    string[] discipleSecondSay = new string[]
    {
        "Don't worry",
        "I have a solution for you.",
        "I will use a spell to make the cart lighter.",
        "So that you can pull it and it would just feel like a normal shopping cart."
    };

    string[] johnThirdDialogue = new string[]
    {
        "WOooOw, what spell is that?",
        "Can I learn it?",
    };

    string[] discipleThirdSay = new string[]
    {
        "No",
        "This is a forbidden spell.",
        "You can't learn it.",
        "And I think it is impossible for you to learn it.",
        "You don't have a talent on it."
    };

    string[] johnFourthDialogue = new string[]
    {
        "...",
        "Alright, then please use your spell to make it lighter now",
        "We need to back to the shrine before the sunrise."
    };

    string[] discipleFourthSay = new string[]
    {
        "Alright",
        "I will use the spell now.",
    };

    string[] readTheSpell = new string[]
    {
        "Wingardium Leviosa!!!"
    };

    string[] johnFifthDialogue = new string[]
    {
        "Is this charm from a novel series?",
        "It sounds familiar..."
    };

    string[] discipleFifthSay = new string[]
    {
        "No",
        "This is a spell from a movie series.",
        "And it is a very powerful spell."
    };

    string[] johnSixDialogue = new string[]
    {
        "......",
        "Alright! Let's back to the shrine now.",
        "Otherwise I will feel hungry again..."
    };

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        ds = DialogueSystem.instance;
        architect = new TextArchitect(ds.dialogueContainer.dialogueText);
        architect.buildMethod = TextArchitect.BuildMethod.typewriter;
        architect.speed = 0.5f;

        currentDialogue = johnFirstDialogue;

        JPVN5Continue.onClick.AddListener(GoToNextScene);

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

                    if (currentDialogue == johnFirstDialogue && dialogueFinished)
                    {
                        DiscipleFirstDialogue();
                    }
                    else if (currentDialogue == discipleFirstSay && dialogueFinished)
                    {
                        JohnSecondDialogue();
                    }
                    else if (currentDialogue == johnSecondDialogue && dialogueFinished)
                    {
                        DiscipleSecondDialogue();
                    }
                    else if (currentDialogue == discipleSecondSay && dialogueFinished)
                    {
                        JohnThirdDialogue();
                    }
                    else if (currentDialogue == johnThirdDialogue && dialogueFinished)
                    {
                        DiscipleThirdDialogue();
                    }
                    else if (currentDialogue == discipleThirdSay && dialogueFinished)
                    {
                        JohnFourthDialogue();
                    }
                    else if (currentDialogue == johnFourthDialogue && dialogueFinished)
                    {
                        DiscipleFourthDialogue();
                    }
                    else if (currentDialogue == discipleFourthSay && dialogueFinished)
                    {
                        UseTheSpell();
                        
                    }
                    else if (currentDialogue == readTheSpell && dialogueFinished)
                    {
                        JohnFifthDialogue();
                    }
                    else if (currentDialogue == johnFifthDialogue && dialogueFinished)
                    {
                        DiscipleFifthDialogue();
                    }
                    else if (currentDialogue == discipleFifthSay && dialogueFinished)
                    {
                        JohnSixDialogue();
                    }
                    else if (currentDialogue == johnSixDialogue && dialogueFinished)
                    {
                        showContinueButton();
                    }
                }
            }
        }
    }

    void DiscipleFirstDialogue()
    {
        //change name tag
        johnNameTagVN5.SetActive(false);
        discipleNameTagVN5.SetActive(true);

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
        johnNameTagVN5.SetActive(true);
        discipleNameTagVN5.SetActive(false);

        dieJohn2.gameObject.SetActive(false);
        aliveJohn2.gameObject.SetActive(true);

        dialogueFinished = false;

        currentDialogue = johnSecondDialogue;
        currentIndex = 0;

        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleSecondDialogue()
    {
        //change name tag
        johnNameTagVN5.SetActive(false);
        discipleNameTagVN5.SetActive(true);

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
        johnNameTagVN5.SetActive(true);
        discipleNameTagVN5.SetActive(false);

        dialogueFinished = false;
        currentDialogue = johnThirdDialogue;

        currentIndex = 0;

        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleThirdDialogue()
    {
        //change name tag
        johnNameTagVN5.SetActive(false);
        discipleNameTagVN5.SetActive(true);

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
        johnNameTagVN5.SetActive(true);
        discipleNameTagVN5.SetActive(false);

        dialogueFinished = false;

        currentDialogue = johnFourthDialogue;
        currentIndex = 0;

        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleFourthDialogue()
    {
        //change name tag
        johnNameTagVN5.SetActive(false);
        discipleNameTagVN5.SetActive(true);
        dialogueFinished = false;
        currentDialogue = discipleFourthSay;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
        
    }

    void UseTheSpell() 
    {
        videoCharming.SetActive(true);

        dialogueFinished = false;
        currentDialogue = readTheSpell;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnFifthDialogue()
    {
        //change name tag
        johnNameTagVN5.SetActive(true);
        discipleNameTagVN5.SetActive(false);
        dialogueFinished = false;
        currentDialogue = johnFifthDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleFifthDialogue()
    {
        //change name tag
        johnNameTagVN5.SetActive(false);
        discipleNameTagVN5.SetActive(true);
        dialogueFinished = false;
        currentDialogue = discipleFifthSay;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnSixDialogue()
    {
        //change name tag
        johnNameTagVN5.SetActive(true);
        discipleNameTagVN5.SetActive(false);
        dialogueFinished = false;
        currentDialogue = johnSixDialogue;
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
            JPVN5Continue.gameObject.SetActive(true);
        }
    }

    public int levelToUnlock = 14;

    void GoToNextScene()
    {
        //if (MainMenuManager.Instance != null)
        //{
        //    MainMenuManager.Instance.isGS5Unlocked = true;
        //}

        //SceneManager.LoadScene(14);

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
            MainMenuManager.Instance.isGS5Unlocked = true;
        }

        SceneManager.LoadScene(14);
    }

    }
