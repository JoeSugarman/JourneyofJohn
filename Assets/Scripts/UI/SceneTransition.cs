using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnimator;
    public float transitionTime = 1.5f;
    [SerializeField] private CanvasGroup panelCanvasGroup;

    private static SceneTransition instance;
    private bool hasPLayedAnimation = false;

    private void Start()
    {
        if (!hasPLayedAnimation)
        {
            StartCoroutine(FadeOut());
            hasPLayedAnimation = true;
        }
        //StartCoroutine(FadeOut());
    }

    private void Update()
    {
        //if (SceneManager.GetActiveScene().buildIndex != SceneManager.GetActiveScene().buildIndex)
        //{
        //    StartCoroutine(FadeIn());
        //}
    }

    IEnumerator FadeIn()
    {
        transitionAnimator.SetTrigger("FadeIn");
        yield return StartCoroutine(Fade(1, 0));
    }

    IEnumerator FadeOut()
    {
        transitionAnimator.SetTrigger("FadeOut");
        yield return StartCoroutine(Fade(0, 1));
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        
        float elapsedTime = 0f;
        while (elapsedTime < transitionTime && hasPLayedAnimation==false)
        {
            panelCanvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        panelCanvasGroup.alpha = endAlpha;
        hasPLayedAnimation = true;
    }

    }
