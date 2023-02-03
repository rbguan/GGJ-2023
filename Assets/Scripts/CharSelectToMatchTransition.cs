using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharSelectToMatchTransition : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    
    public void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    public void ExitCharSelectAnimation()
    {
        _animator.SetTrigger("ExitChar");
    }
    public void EnterFightAnimation()
    {
        _animator.SetTrigger("EnterFight");
    }
}
