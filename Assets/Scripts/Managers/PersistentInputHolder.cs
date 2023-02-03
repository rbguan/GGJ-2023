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
        
    }
}
