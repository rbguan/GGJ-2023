using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MenuFighterActions : MonoBehaviour
{
    
    Fighters currentFighter = Fighters.Count;
    // Start is called before the first frame update
    [SerializeField]
    int playerNum = 0;

    bool playerInit = false;

    public PlayerInput GetAttachedActions()
    {
        return GetComponent<PlayerInput>(); ;
    }


    public void SetCurrentFighter(Fighters newFighter)
    {
        currentFighter = newFighter;
        CharacterSelectGameManager.Instance.SetupSelectedFighterUI(playerNum, currentFighter);
    }

    public Fighters GetCurrentFighter()
    {
        return currentFighter;
    }
    public int GetFighterNum()
    {
        return playerNum;
    }
    private void Awake()
    {

        Debug.Log("ENABLE");
        playerNum = TitleGameManager.Instance.GetPlayerNum();
    }
    void Start()
    {
        Debug.Log("START");

        transform.parent = PersistentInputHolder.Instance.transform;
        PersistentInputHolder.Instance.MenuFighters.Add(this);
        //GetComponent<PlayerInput>().defaultControlScheme = PersistentInputHolder.Instance.GetComponent<PlayerInputManager>().D
    }

    // Update is called once per frame
    void Update()
    {

    }




    public void SelectAction(InputAction.CallbackContext ctx)
    {
            if (ctx.started)
            {
                if (VictoryScreenManager.Instance != null)
                {
                VictoryScreenManager.Instance.ReturnToTitle();
                }

                Debug.Log("SELECT ACTION" + this.gameObject.name);


                if (TitleGameManager.Instance.isOnTitle || !playerInit)
                {

                    if (TitleGameManager.Instance.isOnTitle)
                    {
                        TitleGameManager.Instance.DisableTitle();
                        if (playerInit)
                        {
                        InitalizePlayer();
                        if (playerNum == 1) {

                            
                            PersistentInputHolder.Instance.MenuFighters[1].InitalizePlayer();
                            }
                            else if (playerNum == 2) 
                            {
                            PersistentInputHolder.Instance.MenuFighters[0].InitalizePlayer();
                            }
                        }
                    currentFighter = Fighters.Count;
                }
                    if (!playerInit)
                    {

                        InitalizePlayer();
                       
                    }
                    //initalize 2nd player if it exists
                }
                else
                {
                    CharacterSelectGameManager.Instance.SelectFighter(this);
                }
            

            }
        
    }


    public void DeselectCharacter(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            CharacterSelectGameManager.Instance.DeselectFighter(this);
        }
    }

    public void ChangeCharacter(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            float axis = ctx.ReadValue<float>();
            CharacterSelectGameManager.Instance.ChangeCharacterSelection(axis, this);
        }
    }
    public void InitalizePlayer()
    {

        playerInit = true;
        CharacterSelectGameManager.Instance.PutPlayerOnFirstCard(this);

    }


}
