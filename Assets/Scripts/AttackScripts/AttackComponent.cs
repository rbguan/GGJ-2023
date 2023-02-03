using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AttackComponent : MonoBehaviour
{
    BasicAttack playerBasicAttack;
    FighterActions fighterAction;
    private void Awake()
    {
        fighterAction = new FighterActions();
        fighterAction.Enable();
        playerBasicAttack = GetComponent<BasicAttack>();
        fighterAction.Base.BasicAttack.performed += ctx =>
        {
            playerBasicAttack.PeformAttack();
        };
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        fighterAction.Enable();
    }

    private void OnDisable()
    {
        fighterAction.Disable();
    }
}
