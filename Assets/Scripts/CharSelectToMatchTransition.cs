using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class CharSelectToMatchTransition : MonoBehaviour
{
    public static CharSelectToMatchTransition Instance { get; private set; }
    [SerializeField] private Animator _animator;
    
    public void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    public void ExitCharSelectAnimation()
    {
        _animator.SetTrigger("ExitChar");
        
    }

    public void StartFight()
    {
        SceneManager.LoadScene("SeanScene2");
    }
    public void EnterFightAnimation()
    {
        _animator.SetTrigger("EnterFight");
    }
}
