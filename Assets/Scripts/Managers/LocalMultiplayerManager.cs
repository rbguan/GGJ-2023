using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class LocalMultiplayerManager : MonoBehaviour
{
    public GameObject Tetrisprefab;
    private bool executingGameplay = false;
    FighterActions Controls;

    [SerializeField] int MaxPlayers = 2;
    private List<FighterCore> players;
    private List<FighterCore> newplayers;

    void Awake()
    {

        players = new List<FighterCore>();
        newplayers = new List<FighterCore>();
        // my IInputActionCollection
        Controls = new FighterActions();
        // you must enable
        Controls.Enable();
        // bind controls that any/every device can use
        //Controls.Base.Block.performed += context => StartGame();
        // assign the callback for listening
        InputUser.onUnpairedDeviceUsed += OnUnpairedDeviceUsed;
        // listening will not start until InputUser.listenForUnpairedDeviceActivity > 0
        BeginJoining();
    }

    private void OnDestroy()
    {
        // Avoid lingering calls after play mode has ended!!!
        InputUser.onUnpairedDeviceUsed -= OnUnpairedDeviceUsed;
    }

    void OnUnpairedDeviceUsed(InputControl control, InputEventPtr eventPtr)
    {
        // Ignore anything but button presses.
        Debug.Log("Unpaired device detected" + control.device);
        if ((control is MouseButton || !(control is ButtonControl)))
            return;
        

        // get a new InputUser, now paired with the device
        InputUser user = InputUser.PerformPairingWithDevice(control.device);
        // Create a new instance of input actions to prevent InputUser from triggering actions on another InputUser.
        FighterActions controlsForThisUser = new FighterActions();
        // you must enable the controls to use them
        controlsForThisUser.Enable();
        // the real work is done for us in InputUser
        user.AssociateActionsWithUser(controlsForThisUser);

        GameObject go = Instantiate(Tetrisprefab);
        FighterCore tetris = go.GetComponent<FighterCore>();
        // store the InputUser so you can unpair later
        tetris.user = user;
        // initialize your script with the new controls
        //tetris.SetUpInput(controlsForThisUser);

        // You cannot do things like set the parent transform in this callback, so
        // add the game object to a list of new players for processing in Update()
        newplayers.Add(tetris);

        InputUser.listenForUnpairedDeviceActivity--;
        if (InputUser.listenForUnpairedDeviceActivity == 0)
        {
            EndJoining();
        }
    }

    void BeginJoining()
    {
        InputUser.listenForUnpairedDeviceActivity = MaxPlayers;
        Debug.Log("CALLED HERE");
    }

    void EndJoining()
    {
        InputUser.listenForUnpairedDeviceActivity = 0;
    }

    void Update()
    {
        // add new players
        foreach (var player in newplayers)
        {
            // this is the reason for the newplayers list. This cannot be called in
            // the onpairedDeviceUsed callback above
            player.transform.parent = transform;
            players.Add(player);
        }
        newplayers.Clear();

    }
}