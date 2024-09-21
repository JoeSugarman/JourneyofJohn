using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;


        string[] lines = new string[5]
        {
            "This is a random line of dialogue",
            "I want to say something",
            "I miss Yejin",
            "So much...",
            "What should I do?"
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architect.speed = 0.5f;
        }

        // Update is called once per frame
        void Update()
        {
            if(bm != architect.buildMethod)
            {
                architect.buildMethod = bm;
                architect.Stop();
            }

            if (Input.GetKeyDown(KeyCode.S))
                architect.Stop();

            string longLine = "This is a very long line that I need to test for the result. I dont know what should i type now but I miss someone so much right now!!!!This is a very long line that I need to test for the result. I dont know what should i type now but I miss someone so much right now!!!!This is a very long line that I need to test for the result. I dont know what should i type now but I miss someone so much right now!!!!This is a very long line that I need to test for the result. I dont know what should i type now but I miss someone so much right now!!!!This is a very long line that I need to test for the result. I dont know what should i type now but I miss someone so much right now!!!!";
            if (Input.GetKeyDown(KeyCode.Space)) //single click to start new line, double click make it go faster, triple click to force complete
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;

                    else
                        architect.ForceComplete();
                }
                else
                    // architect.Build(lines[Random.Range(0, lines.Length)]);
                    architect.Build(longLine);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //architect.Append(lines[Random.Range(0, lines.Length)]);
                architect.Append(longLine);

            }
        }
    }
}