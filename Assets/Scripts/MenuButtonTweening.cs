using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuButtonTweening : MonoBehaviour
{
    [SerializeField][Range(0,2)] private float ButtonHoverScale;
    [SerializeField][Range(0,2)] private float ButtonHoverScaleTime;
    [SerializeField][Range(0,2)] private float ButtonDropdownWaitTime;
    [SerializeField][Range(0,10)] private float PlayButtonFadePeriod;
    [SerializeField] private AnimationCurve PlayButtonFadeCurve;
    [SerializeField][Range(0,5)] private float PlayButtonHoverPeriod;
    [SerializeField] private float PlayButtonY;

    [SerializeField][Range(0,10)] private float TitlePulsePeriod;
    [SerializeField][Range(0,5)] private float TitlePulseScale;
    [SerializeField] private AnimationCurve TitlePulseCurve;
    [SerializeField] private AnimationCurve ButtonHoverScaleCurve;
    [SerializeField] private AnimationCurve PlayButtonHoverCurve;
    [SerializeField] private RectTransform Title;
    [SerializeField] private RectTransform PlayButton;
    [SerializeField] private RectTransform TitleSpark;
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
        StartCoroutine(PlayUILoop());
        yield return null;
    }

    private IEnumerator PlayUILoop()
    {
        PlayButton.DOMoveY(Screen.height * PlayButtonY, PlayButtonHoverPeriod).From().SetLoops(-1).SetEase(PlayButtonHoverCurve);
        PlayButton.transform.GetComponent<Image>().DOFade(0, PlayButtonFadePeriod).From().SetLoops(-1).SetEase(PlayButtonFadeCurve);
        Title.transform.DOScale(TitlePulseScale, TitlePulsePeriod).SetLoops(-1).SetEase(TitlePulseCurve);
        TitleSpark.transform.DOScale(TitlePulseScale, TitlePulsePeriod).SetLoops(-1).SetEase(TitlePulseCurve);
        yield return null;
    }
}
