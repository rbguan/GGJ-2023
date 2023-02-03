﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuButtonTweening : MonoBehaviour
{
    [SerializeField][Range(0,2)] private float ButtonHoverScale;
    [SerializeField][Range(0,2)] private float ButtonHoverScaleTime;
    [SerializeField][Range(0,2)] private float ButtonDropdownTime;
    [SerializeField][Range(0,2)] private float ButtonDropdownWaitTime;
    [SerializeField][Range(0,2)] private float TimeGapBetweenEachDrop;
    [SerializeField] private AnimationCurve ButtonDropdownCurve;
    [SerializeField][Range(0,1)] private float ButtonDropdownSquashFactor;
    [SerializeField] private AnimationCurve ButtonDropdownScaleCurve;
 
    [SerializeField] private AnimationCurve ButtonHoverScaleCurve;
    [SerializeField] private RectTransform Title;
    [SerializeField] private RectTransform PlayButton;
    [SerializeField] private RectTransform HowToPlayButton;
    [SerializeField] private RectTransform QuitButton;
    void Start()
    {
        StartCoroutine(LoadInMenuSequence());
    }

    void Update()
    {
        
    }

    public void OnHoverEnterTween(Button button)
    {
        button.GetComponent<RectTransform>().DOScale(ButtonHoverScale,ButtonHoverScaleTime).SetEase(ButtonHoverScaleCurve);
    }

    public void OnHoverExitTween(Button button)
    {
        button.GetComponent<RectTransform>().DOScale(1,ButtonHoverScaleTime).SetEase(ButtonHoverScaleCurve);
    }

    private IEnumerator LoadInMenuSequence()
    {

        
        // Sequence TitleSequence = DOTween.Sequence();
        // TitleSequence.AppendInterval(TimeGapBetweenEachDrop * 4);
        // TitleSequence.Append(Title.DOMoveY(Screen.height * TitleY, ButtonDropdownTime).SetEase(ButtonDropdownCurve));
        // TitleSequence.Join(Title.DOScaleY(ButtonDropdownSquashFactor, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));    
        
        Sequence LoadSequence = DOTween.Sequence();
        LoadSequence.AppendInterval(ButtonDropdownWaitTime);
        // LoadSequence.Join(TitleSequence);
        LoadSequence.Play();
        yield return null;
    }

    private IEnumerator PlayUILoop()
    {
        while(true)
        {
            // PlayButton.DOMoveY()
        }
        yield return null;
    }
}
