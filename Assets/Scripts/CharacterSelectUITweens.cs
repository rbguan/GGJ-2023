using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterSelectUITweens : MonoBehaviour
{
    [Header("Reference Objects")]
    [SerializeField] private RectTransform _player1RectTransform;
    [SerializeField] private RectTransform _player2RectTransform;
    [SerializeField] private Button _startFightButton;
    [SerializeField] private Animator _CharacterSelectUIAnimator;
    private CharSelectToMatchTransition _sceneTransitioner;
    [Header("Start Fight Button Drop Animation Values")]
    [SerializeField][Range(0f, 5f)] private float _dropTime;
    [SerializeField][Range(0f, 5f)] private float _scaleTime;
    [SerializeField][Range(0f, 5f)] private float _buttonScale;
    // [SerializeField][Range(0f, 30f)] private float _rumbleIntensity;

    [Header("Start Fight Rumble Animation Values")]
    [SerializeField][Range(0f, 5f)] private float _waitTime;
    [SerializeField][Range(0f, 5f)] private float _rumbleTime;
    [SerializeField][Range(0f, 30f)] private float _rumbleIntensity;
    [SerializeField][Range(0, 20)] private int _rumbleVibrato;
    [SerializeField][Range(0f, 90f)] private float _rumbleRandomness;
    [Header("Start Fight Smash Together Animation Values")]
    [SerializeField][Range(0f, 5f)] private float _smashTogetherTime;
    [SerializeField][Range(0f, 5f)] private float _zoomOutTime;
    
    [Header("Start Fight Animation Values")]
    [SerializeField] private AnimationCurve _rumbleCurve;
    [SerializeField] private AnimationCurve _dropCurve;
    [SerializeField] private AnimationCurve _dropScaleCurve;
    [SerializeField] private AnimationCurve _smashTogetherTranslateCurve;
    [SerializeField] private AnimationCurve _smashTogetherScaleCurve;
    [SerializeField] private AnimationCurve _smashTogetherYScaleCurve;
    [SerializeField] private AnimationCurve _zoomOutTranslateCurve;
    [SerializeField] private AnimationCurve _zoomOutScaleCurve;

    void Start()
    {
        _sceneTransitioner = FindObjectOfType<CharSelectToMatchTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMatchStartPressed()
    {
        Sequence moveStartMatchButton = DOTween.Sequence();
        moveStartMatchButton.Append(_startFightButton.transform.DOScale(new Vector3(_buttonScale, _buttonScale, _buttonScale), _scaleTime).SetEase(_dropScaleCurve));
        moveStartMatchButton.Insert(0, _startFightButton.transform.DOMoveY(-300f, _dropTime).SetEase(_dropCurve));
        moveStartMatchButton.Play();

        Sequence moveCharacterPortraits = DOTween.Sequence();
        moveCharacterPortraits.Append(_player1RectTransform.DOShakePosition(_rumbleTime, _rumbleIntensity, _rumbleVibrato, _rumbleRandomness, false, true));
        moveCharacterPortraits.Insert( 0, _player2RectTransform.DOShakePosition(_rumbleTime, _rumbleIntensity, _rumbleVibrato, _rumbleRandomness, false, true));
        moveCharacterPortraits.PrependInterval(_waitTime);

        moveCharacterPortraits.Play();
        
        StartCoroutine(PlayerPortraitAnimations());
    }

    private IEnumerator PlayerPortraitAnimations()
    {
        yield return new WaitForSeconds(_waitTime + _rumbleTime);
        _CharacterSelectUIAnimator.enabled = true;
        _CharacterSelectUIAnimator.SetTrigger("LoadFightLevel");
        yield return new WaitForSeconds(.92f);
        CharSelectToMatchTransition.Instance.ExitCharSelectAnimation();
    }
}
