using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class CharacterSelectGameManager : MonoBehaviour
{
    public static CharacterSelectGameManager Instance { get; private set; }

    [SerializeField]
    CharacterSelectUITweens matchTransistion;

    [SerializeField]
    CharacterDataCards[] characterDataCards;

    int playerOneIndex = -1;
    int playerTwoIndex = -1;

    public bool playerOneSelected = false;
    public bool playerTwoSelected = false;

    bool timerCountDown = false;
    bool matchStarted = false;
    [SerializeField]
    float timerBase = 5;
    float currentTime;
    [SerializeField] private Transform _player1PortraitTransform;
    [SerializeField] private Transform _player2PortraitTransform;
    private void Awake()
    {
        Instance = this;
    }

    public void CheckBeginCountDown()
    {
        if (playerOneSelected && playerTwoSelected)
        {
            if (!timerCountDown)
            {
                currentTime = timerBase;
                timerCountDown = true;
            }
        }
        else
        {
            timerCountDown = false;
        }
    }

    public void BeginGame()
    {
        timerCountDown = false;        

        if (playerOneSelected && playerTwoSelected)
        {
            matchStarted = true;
            PersistentInputHolder.Instance.SetInputs(characterDataCards[playerOneIndex].GetFighterAttached(), characterDataCards[playerTwoIndex].GetFighterAttached());
            matchTransistion.OnMatchStartPressed();
            
        }
        //pass both two fighters into the game
    }

    public void PutPlayerOnFirstCard(MenuFighterActions currentPlayer)
    {
        Debug.Log(currentPlayer.GetFighterNum());

        if (currentPlayer.GetFighterNum() == 1)
        {
            playerOneIndex = 0;
            characterDataCards[playerOneIndex].playerOneSelectionImage.SetActive(true);
            Debug.Log("P1 ON CARD NUMBER 0");
        }
        else if (currentPlayer.GetFighterNum() == 2)
        {
            playerTwoIndex = 0;
            characterDataCards[playerTwoIndex].playerTwoSelectionImage.SetActive(true);
            Debug.Log("P2 ON CARD NUMBER 0");
        }

        
    }

    
    public void SelectFighter(MenuFighterActions currentPlayer)
    {
        if (currentPlayer.GetFighterNum() == 1) {
            if (playerOneIndex < 0)
                return;

            currentPlayer.SetCurrentFighter(characterDataCards[playerOneIndex].GetFighterAttached());
            playerOneSelected = true;           
        }
        else if (currentPlayer.GetFighterNum() == 2)
        {
            if (playerTwoIndex < 0)
                return;
            
            currentPlayer.SetCurrentFighter(characterDataCards[playerTwoIndex].GetFighterAttached());
            playerTwoSelected = true;           
        }

        Debug.Log("SELECTEDFIGHTER IS " + currentPlayer.GetCurrentFighter().ToString() + " " + currentPlayer.name);
    }

    public void SetupSelectedFighterUI(int currentPlayerNum, Fighters currentFighter)
    {
        if(currentPlayerNum == 1)
        {
            // _player1PortraitTransform.GetComponent<Image>() = currentFighter.
        }
        else
        {

        }
    }
    public void DeselectFighter(MenuFighterActions currentPlayer)
    {
        currentPlayer.SetCurrentFighter(Fighters.Count);
        
        
        if (currentPlayer.GetFighterNum() == 1)
            playerOneSelected = false;
        else if (currentPlayer.GetFighterNum() == 2)
            playerTwoSelected = false;

        timerCountDown = false;

        Debug.Log("DESELECTED FIGHTER IS " + currentPlayer.GetCurrentFighter().ToString());
    }

    public void ChangeCharacterSelection(float axis, MenuFighterActions currentFighter)
    {
        if (currentFighter.GetCurrentFighter() != Fighters.Count)
            return;

        if (currentFighter.GetFighterNum() == 1)
        {
            characterDataCards[playerOneIndex].playerOneSelectionImage.SetActive(false);
            playerOneIndex = ChangeIndex(axis, playerOneIndex);
            characterDataCards[playerOneIndex].playerOneSelectionImage.SetActive(true);
            Debug.Log("P1 new index is " + playerOneIndex);
        }
        else if (currentFighter.GetFighterNum() == 2)
        {
            characterDataCards[playerTwoIndex].playerTwoSelectionImage.SetActive(false);
            playerTwoIndex = ChangeIndex(axis, playerTwoIndex);
            characterDataCards[playerTwoIndex].playerTwoSelectionImage.SetActive(true);
            Debug.Log("P2 new index is " + playerTwoIndex);
        }
    }

    int ChangeIndex(float axis, int currentIndex)
    {
        if (axis > 0)
        {
            currentIndex += 1;
        }
        else if (axis < 0)
        {
            currentIndex -= 1;
        }

        if (currentIndex < 0)
            currentIndex = characterDataCards.Length - 1;
        else if (currentIndex > characterDataCards.Length - 1)
            currentIndex = 0;

        return currentIndex;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!matchStarted)
        {
            CheckBeginCountDown();

            if (timerCountDown)
            {
                currentTime -= Time.deltaTime;
                Debug.Log(currentTime);
                if (currentTime <= 0)
                {
                    BeginGame();
                }
            }

        }
    }
}

public enum Fighters
{
    Root,
    Toot,
    Shoot,
    Count
}
