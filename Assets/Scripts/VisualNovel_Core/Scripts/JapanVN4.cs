using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JapanVN4 : MonoBehaviour
{
    DialogueSystem ds;
    TextArchitect architect;

    private string[] currentDialogue;
    bool dialogueFinished = false;

    //dialogue name tag
    public GameObject johnNameTagVN4;
    public GameObject discipleNameTagVN4;
    public GameObject descriptionNameTag;
    public GameObject Tree;

    //image and video
    public UnityEngine.UI.Image woodlogcart;
    public GameObject video;

    //button
    public UnityEngine.UI.Button JPVN4Continue;

    //The sound of chopping trees
    string[] choppingSound = new string[]
    { 
        "Thawk! Thawk! Thawk! Thawk! Thawk! Thawk! Thawk! Thawk!",
        "Thawk! Thawk! Thawk! Thawk! Thawk! Thawk! Thawk! Thawk!",
        "Thawk! Thawk! Thawk! Thawk! Thawk! Thawk! Thawk! Thawk!"
    };

    //desciption
    string[] description = new string[]
    {
        "They are using magic power to chop the woods..."
    };

    //john first dialogue
    string[] johnFirstDialogue = new string[]
    {
        "Hey master, we have chopped trees for almost 10 hours already.",
        "How many trees do we need for reparing the ancient artefacts?",
        "Look at the cart...",
        "We have almost a ton of wood now."
    };

    string[] discipleFirstSay = new string[]
    {
        "John, we need to chop more trees.",
        "We need at least 2 tons of wood to repair the ancient artefacts.",
        "At least you are using the magic power that I taught you to chop the wood",
        "It is less hard as usual.",
    };

    string[] johnSecondDialogue = new string[]
    {
        "Master, even though it is less hard to chop the wood.",
        "Using magic still consuming my energy.",
        "And more importantly",
        "How can we bring the logs back to the shrine?"
    };

    string[] discipleSecondSay = new string[]
    {
        "Don't worry, I have a plan.",
        "It would work well, and you won't die from exhaustion.",
        "Starting from now, let's collect the wood as much as possible."
    };

    // Start is called before the first frame update
    void Start()
    {
        ds = DialogueSystem.instance;
        architect = new TextArchitect(ds.dialogueContainer.dialogueText);
        architect.buildMethod = TextArchitect.BuildMethod.typewriter;
        architect.speed = 0.5f;

        //assign first dialogue
        currentDialogue = choppingSound;

        //add listener to button
        JPVN4Continue.onClick.AddListener(GoToNextScene);
        //deactivate objects

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

                    if (currentDialogue == choppingSound && dialogueFinished)
                        Descriptionofnarration();
                    else if (currentDialogue == description && dialogueFinished)
                        JohnFirstDialogue();
                    else if (currentDialogue == johnFirstDialogue && dialogueFinished)
                        DiscipleFirstSay();
                    else if (currentDialogue == discipleFirstSay && dialogueFinished)
                        JohnSecondDialogue();
                    else if (currentDialogue == johnSecondDialogue && dialogueFinished)
                        DiscipleSecondSay();
                    else if (currentDialogue == discipleSecondSay && dialogueFinished)
                        showContinueButton();
                }
            }
        }
    }

    void Descriptionofnarration() 
    {
        dialogueFinished = false;

        //turn off and on name tag
        Tree.gameObject.SetActive(false);
        descriptionNameTag.gameObject.SetActive(true);

        currentDialogue = description;

        currentIndex = 0;

        if (currentIndex < currentDialogue.Length) 
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void JohnFirstDialogue()
    {
        dialogueFinished = false;
        //turn off and on name tag
        descriptionNameTag.gameObject.SetActive(false);
        johnNameTagVN4.gameObject.SetActive(true);
        currentDialogue = johnFirstDialogue;
        currentIndex = 0;
        if (currentIndex < currentDialogue.Length)
        {
            architect.Build(currentDialogue[currentIndex]);
            currentIndex++;
        }
    }

    void DiscipleFirstSay()
    {
        dialogueFinished = false;
        //turn off and on name tag
        johnNameTagVN4.gameObject.SetActive(false);
        discipleNameTagVN4.gameObject.SetActive(true);
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
        dialogueFinished = false;
        //turn off and on name tag
        discipleNameTagVN4.gameObject.SetActive(false);
        johnNameTagVN4.gameObject.SetActive(true);
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
        dialogueFinished = false;
        //turn off and on name tag
        johnNameTagVN4.gameObject.SetActive(false);
        discipleNameTagVN4.gameObject.SetActive(true);
        currentDialogue = discipleSecondSay;
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
            JPVN4Continue.gameObject.SetActive(true);
        }
    }

    public int levelToUnlock = 11;

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
        SceneManager.LoadScene(11);
    }

}
