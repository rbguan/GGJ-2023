using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class VictoryScreenManager : MonoBehaviour
{
    public static VictoryScreenManager Instance { get; private set; }

    [SerializeField]
    GameObject[] playerText;
    
    [SerializeField]
    GameObject[] winningPlayerGraphic;

    [SerializeField]
    GameObject[] losingPlayerGraphic;

    [SerializeField] AudioSource VOSrc;

    [SerializeField]
    AudioClip[] AnnouncerClips;

    [SerializeField]
    AudioClip[] FighterWinClips;
    [Header("UI Drop In Values")]
    [SerializeField] private float _dropInTime;
    [SerializeField] private float _startScaleX;
    [SerializeField] private AnimationCurve _scaleXCurve;
    [SerializeField] private float _bounceInTime;
    [SerializeField] private AnimationCurve _bounceInScaleCurve;
    [SerializeField] private AnimationCurve _alphaCurve;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        StartCoroutine(LoadInUITweens());
        // if (PersistentInputHolder.Instance.GetWinningPlayerNum() == 1)
        // {
        //     playerText[0].SetActive(true);

        // }
        // else if (PersistentInputHolder.Instance.GetWinningPlayerNum() == 2)
        // {
        //     playerText[1].SetActive(true);
        // }

        // winningPlayerGraphic[(int)PersistentInputHolder.Instance.GetWinningFighter()].SetActive(true);
        // losingPlayerGraphic[(int)PersistentInputHolder.Instance.GetLosingFighter()].SetActive(true);

        if (PersistentInputHolder.Instance != null && PersistentInputHolder.Instance.MenuFighters.Count >= 2)
        {
            for (int i = 0; i < PersistentInputHolder.Instance.GetInputs().Length; i++)
            {
                foreach (MenuFighterActions menuFighter in PersistentInputHolder.Instance.MenuFighters)
                {
                    if (menuFighter.GetFighterNum() == i + 1)
                    {
                        menuFighter.GetAttachedActions().SwitchCurrentActionMap("Menu");
                        menuFighter.SetCurrentFighter(Fighters.Count);
                        Debug.Log(menuFighter.GetAttachedActions().currentActionMap.name);
                    }
                }

            }
        }


        StartCoroutine(PlayVO(PersistentInputHolder.Instance.GetWinningFighter()));

    }
    private IEnumerator LoadInUITweens()
    {
        int playerTextIndex = 0;
        if (PersistentInputHolder.Instance.GetWinningPlayerNum() == 1)
        {
            playerTextIndex = 0;
            playerText[0].SetActive(true);

        }
        else if (PersistentInputHolder.Instance.GetWinningPlayerNum() == 2)
        {
            playerTextIndex = 1;
            playerText[1].SetActive(true);
        }
        playerText[playerTextIndex].SetActive(true);
        playerText[playerTextIndex].transform.DOScaleX(_startScaleX, _dropInTime).From().SetEase(_scaleXCurve);
        playerText[playerTextIndex].GetComponent<Image>().DOFade(0, _dropInTime).From().SetEase(_alphaCurve);
        
        winningPlayerGraphic[(int)PersistentInputHolder.Instance.GetWinningFighter()].SetActive(true);
        winningPlayerGraphic[(int)PersistentInputHolder.Instance.GetWinningFighter()].GetComponent<Image>().transform.DOScale(0, _bounceInTime).From().SetEase(_bounceInScaleCurve);
        winningPlayerGraphic[(int)PersistentInputHolder.Instance.GetWinningFighter()].GetComponent<Image>().DOFade(0, _bounceInTime).From().SetEase(_alphaCurve);
        
        losingPlayerGraphic[(int)PersistentInputHolder.Instance.GetLosingFighter()].SetActive(true);
        losingPlayerGraphic[(int)PersistentInputHolder.Instance.GetLosingFighter()].GetComponent<Image>().transform.DOScale(0, _bounceInTime).From().SetEase(_bounceInScaleCurve);
        losingPlayerGraphic[(int)PersistentInputHolder.Instance.GetLosingFighter()].GetComponent<Image>().DOFade(0, _bounceInTime).From().SetEase(_alphaCurve);
        yield return null;
    }
    private void OnDisable()
    {
    }

    public void ReturnToTitle()
    {
        StopAllCoroutines();
        StartCoroutine(hold());
    }

    private IEnumerator hold()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    private IEnumerator PlayVO(Fighters winningFighter)
    {
        yield return new WaitForSeconds(5f);
        VOSrc.PlayOneShot(AnnouncerClips[(int)winningFighter]);
        yield return new WaitForSeconds(4f);
        VOSrc.PlayOneShot(FighterWinClips[(int)winningFighter]);
    }

}
