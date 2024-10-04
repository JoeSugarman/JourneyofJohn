using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        string[] lines = new string[]
        {
            "hello",
            "how are u",
            "yo",
            "hehe",
            "haha"
        };
        private int currentIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.typewriter;
            architect.speed = 0.5f;
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
                    if (currentIndex < lines.Length)
                    {
                        architect.Build(lines[currentIndex]);
                        currentIndex++;
                    }
                    else
                    {
                        GoToNextScene();
                    }
                }
            }
            //else if (Input.GetKeyDown(KeyCode.A))
            //{
            //    architect.Append(lines[Random.Range(0, lines.Length)]);
            //}
        }

        void GoToNextScene()
        {
            // Replace "NextSceneName" with the actual name of your next scene
            SceneManager.LoadScene(3);
        }
    }
}
