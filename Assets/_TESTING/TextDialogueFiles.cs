using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDialogueFiles : MonoBehaviour
{
    //[SerializeField] private TextAsset file;

    // Start is called before the first frame update
    void Start()
    {
        StartConversation();
    }

    void StartConversation()
    {
        List<string> lines = FileManager.ReadTextAsset("testFile");

        DialogueSystem.instance.Say(lines);
    }
}
