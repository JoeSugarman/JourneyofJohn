using System.Collections;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class TextArchitect 
{
    private TextMeshProUGUI tmpro_ui;
    private TextMeshPro tmpro_world; //world space 3d text
    public TMP_Text tmpro => tmpro_ui != null ? tmpro_ui : tmpro_world;

    public string currentText => tmpro.text;
    public string targetText { get; private set; } = "";
    public string preText { get; private set; } = ""; //store the text before the current text
    private int preTextLength = 0;

    public string fullTargetText => preText + targetText;

    public enum BuildMethod { instant, typewriter, fade };
    public BuildMethod buildMethod = BuildMethod.typewriter;

    public Color textColor { get { return tmpro.color; } set { tmpro.color = value; } }

    //speed of typewriter or fade
    public float speed { get { return baseSpeed * speedMultiplier; } set { speedMultiplier = value; } }
    private const float baseSpeed = 1;
    private float speedMultiplier = 1;

    public int charactersPerCycle { get { return speed <= 2f ? characterMuiltiplier : speed <= 2.5f ? characterMuiltiplier * 2 : characterMuiltiplier * 3; } }
    private int characterMuiltiplier = 1;

    public bool hurryUp = false;

    public TextArchitect(TextMeshProUGUI tmpro_ui)
    {
        this.tmpro_ui = tmpro_ui;
    }

    public TextArchitect(TextMeshPro tmpro_world)
    {
        this.tmpro_world = tmpro_world;
    }

    public Coroutine Build(string text)
    {
        preText = "";
        targetText = text;

        Stop();

        BuildProcess = tmpro.StartCoroutine(Building());
        return BuildProcess;
    }

    /// <summary>
    /// append text to what is already displayed.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public Coroutine Append(string text)
    {
        preText = tmpro.text;
        targetText = text;

        Stop();

        BuildProcess = tmpro.StartCoroutine(Building());
        return BuildProcess;
    }

    private Coroutine BuildProcess = null;
    public bool isBuilding => BuildProcess != null;

    public void Stop()
    {
        if(!isBuilding) return;

        tmpro.StopCoroutine(BuildProcess);
        BuildProcess = null;
    }

    IEnumerator Building()
    {
        Prepare();

        switch (buildMethod)
        {
            case BuildMethod.typewriter:
                yield return Build_TypeWriter();
                break;
            case BuildMethod.fade:
                yield return Build_Fade();
                break;
        }

        OnComplete();
    }

    private void OnComplete()
    {
        BuildProcess = null;
    }

    private void Prepare()
    {
        switch(buildMethod)
        {
            case BuildMethod.instant:
                Prepare_Instant();
                break;
            case BuildMethod.typewriter:
                Prepare_TypeWriter();
                break;
            case BuildMethod.fade:
                Prepare_Fade();
                break;
        }
    }

    private void Prepare_Instant()
    {
        tmpro.color = tmpro.color; //force it to reinitialize
        tmpro.text = fullTargetText;
        tmpro.ForceMeshUpdate(); //udpate the change
        tmpro.maxVisibleCharacters = tmpro.textInfo.characterCount; //show all characters

    }
    private void Prepare_TypeWriter()
    {

    }
    private void Prepare_Fade()
    {

    }

    private IEnumerator Build_TypeWriter()
    {
        yield return null;
    }

    private IEnumerator Build_Fade()
    {
        yield return null;
    }
}
