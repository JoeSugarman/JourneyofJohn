using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JapanVN6 : MonoBehaviour
{
    DialogueSystem ds;
    TextArchitect architect;

    private string[] currentDialogue;
    bool dialogueFinished = false;

    //dialogue name tag
    public GameObject johnNameTagVN6;
    public GameObject discipleNameTagVN6;
    public GameObject priestNameTagVN6;


    //image and video
    public UnityEngine.UI.Image priestWaitingShot;
    public UnityEngine.UI.Image twoGuysHiking;
    public UnityEngine.UI.Image snowShrine;

    //character
    public UnityEngine.UI.Image JPVN6John;
    public UnityEngine.UI.Image JPVN6DieJohn;
    public UnityEngine.UI.Image JPVN6ArriveJohn;
    public UnityEngine.UI.Image JPVN6Disciple;
    public UnityEngine.UI.Image JPVN6ArriveDisciple;
    public UnityEngine.UI.Image JPVN6Priest;
    public UnityEngine.UI.Image Deer;
    public UnityEngine.UI.Image cartJPVN6;

    //button
    public UnityEngine.UI.Button nextButton;
    public GameObject nextButtonText;

    string[] priestFirstDialogue = new string[]
    {
        "Hummm, why they leave so long?",
        "It even starts snowing...",
        "And my hair become even whiter.",
        "Hummm?",
        "You said I am worrying about them?",
        "No, I didn't.",
        "Really didn't.",
        "I am just a little bit curious.",
        "Let's wait for more time."
    };

    string[] johnFirstDialogue = new string[]
    {
        "I am so tired.",
        "I can't walk anymore.",
        "I am so hungry.",
        "I am so thirsty.",
        "I am so cold.",
        "I am so sleepy.",
        "How long is the road left?"
    };

    string[] discipleFirstDialogue = new string[]
    {
        "Why are you so weak?",
        "But we are almost there.",
        "Probably an hour left.",
        "I don't have any food left so don't look at me with your eyes like this."
    };

    string[] johnSecondDialogue = new string[]
    {
        "...",
        "Alright. I think I can walk a little bit more.",
        "Ohhhhh!!! Here is a deer!!!",
        "I am so hungry..."
    };

    string[] discipleSecondDialogue = new string[]
    {
        "Bro!!!",
        "Don't scare the deer away!!!",
        "We don't eat it!!!",
        "We are almost there!!!",
        "Just keep walking!!!"
    };

    string[] johnThirdDialogue = new string[] 
    {
        "YEAHHHHH!!! WE ARRIVE!!!",
        "I can't believe it!!!"
    };

    string[] priestSecondDialogue = new string[]
    {
        "Oh, you guys are finally here", 
        "Did you guys prepare enough woods?",
        "How is the journey?",
        "I believe you guys have a lot of stories to tell me.",
        "It must be fun :)"
    };

    string[] johnFourthDialogue = new string[]
    {
        "No, it isn't.",
        "I nearly die during the journey.",
        "I am so hungry, so thirsty, so cold, so sleepy now.",
        "Jag vill sova som en stock!"
    };

    string[] priestThirdDialogue = new string[]
    {
        "Hahaha.",
        "But you guys are here now.",
        "And don't sleep now, I will let you choose the next destination very soon."
    };

    string[] johnFifthDialogue = new string[]
    {
        "Really? I am so excited now!!!",
        "I can't wait!!!" ,
        "What is the method you are going to send me with?"
    };

    string[] priestThirdDialogue2 = new string[]
    {
        "Do you know what is wormhole?",
        "In a night, I suddenly figure out how to use wormhole to compress 2 location.",
        "Then, I made a door which has the ability to create wormhole.",
        "Thus, there is a tunnel for us to travel very long distance in a short distance."
    };

    string[] johnSixthDialogue = new string[]
    {
        "Wow!!!",
        "You mean you made an anywhere door?",
        "Are you Doraemon?"
    };

    string[] priestFourthDialogue = new string[]
    {
        "What is Doraemon?" 
    };

    string[] priestFifthDialogue = new string[] 
    {
        "Anyways, here is the door.",
        "Think a destination you want to go, and then open the door."
    };

    // Start is called before the first frame update
    void Start()
    {
        ds = DialogueSystem.instance;
        architect = new TextArchitect(ds.dialogueContainer.dialogueText);
        architect.buildMethod = TextArchitect.BuildMethod.typewriter;
        architect.speed = 0.5f;

        currentDialogue = priestFirstDialogue;

        nextButton.onClick.AddListener(GoToNextScene);
    }

    private int currentIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Mouse0))
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

                    if (currentDialogue == priestFirstDialogue && dialogueFinished)
                        JohnFirstDialogue();
                    else if (currentDialogue == johnFirstDialogue && dialogueFinished)
                        DiscipleFirstDialogue();
                    else if (currentDialogue == discipleFirstDialogue && dialogueFinished)
                        JohnSecondDialogue();
                    else if (currentDialogue == johnSecondDialogue && dialogueFinished)
                        DiscipleSecondDialogue();
                    else if (currentDialogue == discipleSecondDialogue && dialogueFinished)
                        JohnThirdDialogue();
                    else if (currentDialogue == johnThirdDialogue && dialogueFinished)
                        PriestSecondDialogue();
                    else if (currentDialogue == priestSecondDialogue && dialogueFinished)
                        JohnFourthDialogue();
                    else if (currentDialogue == johnFourthDialogue && dialogueFinished)
                        PriestThirdDialogue();
                    else if (currentDialogue == priestThirdDialogue && dialogueFinished)
                        JohnFifthDialogue();
                    else if (currentDialogue == johnFifthDialogue && dialogueFinished)
                        PriestThirdDialogue2();
                    else if (currentDialogue == priestThirdDialogue2 && dialogueFinished)
                        JohnSixthDialogue();
                    else if (currentDialogue == johnSixthDialogue && dialogueFinished)
                        PriestFourthDialogue();
                    else if (currentDialogue == priestFourthDialogue && dialogueFinished)
                    {
                        showContinueButton();
                        PriestFifthDialogue();
                    }
                    

                }
            }
        }
    }
    
    void JohnFirstDialogue()
    {
        //change the name tag
        johnNameTagVN6.SetActive(true);
        priestNameTagVN6.SetActive(false);

        //change background pic
        priestWaitingShot.gameObject.SetActive(false);
        twoGuysHiking.gameObject.SetActive(true);

        //turn on character
        JPVN6DieJohn.gameObject.SetActive(true);
        JPVN6Disciple.gameObject.SetActive(true);
        Deer.gameObject.SetActive(true);

        dialogueFinished = false;
        currentDialogue = johnFirstDialogue;
        currentIndex = 0;

        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }

    }

    void DiscipleFirstDialogue()
    {
        //change the name tag
        discipleNameTagVN6.SetActive(true);
        johnNameTagVN6.SetActive(false);
        dialogueFinished = false;
        currentDialogue = discipleFirstDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnSecondDialogue()
    {
        JPVN6DieJohn.gameObject.SetActive(false);
        JPVN6John.gameObject.SetActive(true);
        johnNameTagVN6.SetActive(true);
        discipleNameTagVN6.SetActive(false);

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
        discipleNameTagVN6.SetActive(true);
        johnNameTagVN6.SetActive(false);

        dialogueFinished = false;
        currentDialogue = discipleSecondDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnThirdDialogue()
    {
        johnNameTagVN6.SetActive(true);
        discipleNameTagVN6.SetActive(false);

        //change background pic
        twoGuysHiking.gameObject.SetActive(false);
        snowShrine.gameObject.SetActive(true);

        //turn on character
        JPVN6John.gameObject.SetActive(false);
        JPVN6Disciple.gameObject.SetActive(false);
        Deer.gameObject.SetActive(false);
        JPVN6Priest.gameObject.SetActive(true);
        JPVN6ArriveDisciple.gameObject.SetActive(true);
        cartJPVN6.gameObject.SetActive(true);
        JPVN6ArriveJohn.gameObject.SetActive(true);

        dialogueFinished = false;
        currentDialogue = johnThirdDialogue;

        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void PriestSecondDialogue()
    {
        priestNameTagVN6.SetActive(true);
        johnNameTagVN6.SetActive(false);
        discipleNameTagVN6.SetActive(false);
        dialogueFinished = false;
        currentDialogue = priestSecondDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnFourthDialogue()
    {
        johnNameTagVN6.SetActive(true);
        priestNameTagVN6.SetActive(false);
        dialogueFinished = false;
        currentDialogue = johnFourthDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void PriestThirdDialogue()
    {
        priestNameTagVN6.SetActive(true);
        johnNameTagVN6.SetActive(false);
        dialogueFinished = false;
        currentDialogue = priestThirdDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnFifthDialogue()
    {
        johnNameTagVN6.SetActive(true);
        priestNameTagVN6.SetActive(false);
        dialogueFinished = false;
        currentDialogue = johnFifthDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void PriestThirdDialogue2()
    {
        priestNameTagVN6.SetActive(true);
        johnNameTagVN6.SetActive(false);
        dialogueFinished = false;
        currentDialogue = priestThirdDialogue2;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnSixthDialogue()
    {
        johnNameTagVN6.SetActive(true);
        priestNameTagVN6.SetActive(false);
        dialogueFinished = false;
        currentDialogue = johnSixthDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void PriestFourthDialogue()
    {
        priestNameTagVN6.SetActive(true);
        johnNameTagVN6.SetActive(false);
        dialogueFinished = false;
        currentDialogue = priestFourthDialogue;
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
            nextButton.gameObject.SetActive(true);
        }
    }

    void GoToNextScene()
    {
        SceneManager.LoadScene(15);
    }

    void PriestFifthDialogue()
    {
        priestNameTagVN6.SetActive(true);
        johnNameTagVN6.SetActive(false);
        nextButtonText.SetActive(true);
        dialogueFinished = false;
        currentDialogue = priestFifthDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }
}
