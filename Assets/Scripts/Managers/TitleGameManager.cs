using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TitleGameManager : MonoBehaviour
{
    public static TitleGameManager Instance { get; private set; }
    [SerializeField]
    GameObject title;
    public bool isOnTitle = true;

    int currentPlayers = 0;

    public int GetPlayerNum()
    {
        if (currentPlayers >= 2)
        {
            Debug.LogWarning("WARNING TOO MANY PLAYERS");
        }
        currentPlayers += 1;
        return currentPlayers;
    }

    private void Awake()
    {
        Instance = this;
    }

    
    public void DisableTitle()
    {
        title.SetActive(false);
        isOnTitle = false;
    }

    public void AssignPlayers()
    {
        
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
