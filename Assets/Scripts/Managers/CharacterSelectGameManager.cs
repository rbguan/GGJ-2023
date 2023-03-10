using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
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
    [SerializeField] private TextMeshProUGUI _player1Name;
    [SerializeField] private Transform _player2PortraitTransform;
    [SerializeField] private TextMeshProUGUI _player2Name;

    [Header("Audio")]
    [SerializeField] private AudioSource VOSrc;
    [SerializeField] private AudioClip RootSelectVO1;
    [SerializeField] private AudioClip RootSelectVO2;
    [SerializeField] private AudioClip TootSelectVO1;
    [SerializeField] private AudioClip TootSelectVO2;
    [SerializeField] private AudioClip ShootSelectVO1;
    [SerializeField] private AudioClip ShootSelectVO2;

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
            _player1PortraitTransform.GetComponent<Image>().sprite = characterDataCards[playerOneIndex].GetTempImage();
            _player1Name.text = "Press Enter / Face Button Down";
            Debug.Log("P1 ON CARD NUMBER 0");
        }
        else if (currentPlayer.GetFighterNum() == 2)
        {
            playerTwoIndex = 0;
            characterDataCards[playerTwoIndex].playerTwoSelectionImage.SetActive(true);
            _player2PortraitTransform.GetComponent<Image>().sprite = characterDataCards[playerTwoIndex].GetTempImage();
            _player2Name.text = "Press Enter / Face Button Down";
            Debug.Log("P2 ON CARD NUMBER 0");
        }

        
    }

    
    public void SelectFighter(MenuFighterActions currentPlayer)
    {
        if (currentPlayer.GetFighterNum() == 1) {
            if (playerOneIndex < 0)
                return;

            currentPlayer.SetCurrentFighter(characterDataCards[playerOneIndex].GetFighterAttached());
            if (_player1PortraitTransform != null)
            {
                _player1PortraitTransform.GetComponent<Image>().sprite = characterDataCards[playerOneIndex].GetCharacterImage();
                _player1Name.text = characterDataCards[playerOneIndex].GetFighterAttached().ToString();
            }
            playerOneSelected = true;           
        }
        else if (currentPlayer.GetFighterNum() == 2)
        {
            if (playerTwoIndex < 0)
                return;
            
            currentPlayer.SetCurrentFighter(characterDataCards[playerTwoIndex].GetFighterAttached());
            if (_player2PortraitTransform != null)
            {
                _player2PortraitTransform.GetComponent<Image>().sprite = characterDataCards[playerTwoIndex].GetCharacterImage();
                _player2Name.text = characterDataCards[playerTwoIndex].GetFighterAttached().ToString();
            }
            playerTwoSelected = true;           
        }

        Debug.Log("SELECTEDFIGHTER IS " + currentPlayer.GetCurrentFighter().ToString() + " " + currentPlayer.name);
        PlaySelectVO(currentPlayer.GetCurrentFighter());
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
        {
            playerOneSelected = false;
            _player1Name.text = "Press Enter / Face Button Down";
            _player1PortraitTransform.GetComponent<Image>().sprite = characterDataCards[playerOneIndex].GetTempImage();
        }
        else if (currentPlayer.GetFighterNum() == 2)
        {
            playerTwoSelected = false;
            _player2Name.text = "Press Enter / Face Button Down";
            _player2PortraitTransform.GetComponent<Image>().sprite = characterDataCards[playerTwoIndex].GetTempImage();
        }

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
            _player1PortraitTransform.GetComponent<Image>().sprite = characterDataCards[playerOneIndex].GetTempImage();
            _player1Name.text = "Press Enter / Face Button Down";
            Debug.Log("P1 new index is " + playerOneIndex);
        }
        else if (currentFighter.GetFighterNum() == 2)
        {
            characterDataCards[playerTwoIndex].playerTwoSelectionImage.SetActive(false);
            playerTwoIndex = ChangeIndex(axis, playerTwoIndex);
            characterDataCards[playerTwoIndex].playerTwoSelectionImage.SetActive(true);
            _player2PortraitTransform.GetComponent<Image>().sprite = characterDataCards[playerTwoIndex].GetTempImage();
            _player2Name.text = "Press Enter / Face Button Down";
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

    private void PlaySelectVO(Fighters fighter)
    {
        AudioClip selectClip;

        switch (fighter)
        {
            case Fighters.Root:
            {
                selectClip = UtilityFunctionLibrary.RandomBool() ? RootSelectVO1 : RootSelectVO2;
                break;
            }
            case Fighters.Toot:
            {
                selectClip = UtilityFunctionLibrary.RandomBool() ? TootSelectVO1 : TootSelectVO2;
                break;
            }
            case Fighters.Shoot:
            {
                selectClip = UtilityFunctionLibrary.RandomBool() ? ShootSelectVO1 : ShootSelectVO2;
                break;
            }
            default:
            {
                selectClip = RootSelectVO1;
                break;
            }
        }

        VOSrc.PlayOneShot(selectClip);
    }
}

public enum Fighters
{
    Root,
    Toot,
    Shoot,
    Count
}
