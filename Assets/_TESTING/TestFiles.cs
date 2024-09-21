using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFiles : MonoBehaviour
{
    [SerializeField]private TextAsset fileName;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Run());
    }

    //IEnumerator Run() //use this if you want to read from a file
    //{
    //    List<string> Lines = FileManager.ReadTextFile(fileName, false); //true include black lines, false exclude black lines

    //    foreach (string line in Lines)
    //        Debug.Log(line);

    //    yield return null;
    //}    

    IEnumerator Run() //use this if you want to read from a text asset
    {
        List<string> Lines = FileManager.ReadTextAsset(fileName, false); //true include black lines, false exclude black lines

        foreach (string line in Lines)
            Debug.Log(line);

        yield return null;
    }
}
