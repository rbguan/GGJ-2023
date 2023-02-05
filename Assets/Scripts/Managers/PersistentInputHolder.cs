using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PersistentInputHolder : MonoBehaviour
{
    public static PersistentInputHolder Instance { get; private set; }
    PlayerInputManager pim;
    [SerializeField]
    Fighters[] playerInputs = new Fighters[2];
    int winningPlayerNum = -1; //either 1 or p1 or 2 for p2
    int losingPlayerNum = -1;

    public List<MenuFighterActions> MenuFighters = new List<MenuFighterActions>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            pim = GetComponent<PlayerInputManager>();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetWinner(int playerNum)
    {
        winningPlayerNum = playerNum;

        if (winningPlayerNum == 1)
            losingPlayerNum = 2;
        else if (winningPlayerNum == 2)
            losingPlayerNum = 1;


    }

    public int GetWinningPlayerNum()
    {
        return winningPlayerNum;
    }

    public int GetLosingPlayerNum()
    {
        return losingPlayerNum;
    }

    public Fighters GetWinningFighter()
    {
        return playerInputs[winningPlayerNum - 1];
    }

    public Fighters GetLosingFighter()
    {
        return playerInputs[losingPlayerNum - 1];
    }

    public void SetInputs(Fighters player1, Fighters player2)
    {
        playerInputs[0] = player1;        
        playerInputs[1] = player2;
        pim.joinBehavior = PlayerJoinBehavior.JoinPlayersManually;
    }

    public Fighters[] GetInputs()
    {
        return playerInputs;
    }

    public PlayerInputManager GetPlayerInputManager()
    {
        if (pim != null)
        {
            return pim;
        }
        else
        {
            return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerInputManager>().playerCount >= GetComponent<PlayerInputManager>().maxPlayerCount)
        {
            GetComponent<PlayerInputManager>().joinBehavior = PlayerJoinBehavior.JoinPlayersManually;
        }
    }
}
