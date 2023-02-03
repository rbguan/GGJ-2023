using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataCards : MonoBehaviour
{
    [SerializeField]
    Fighters attachedFighter;

    public GameObject playerOneSelectionImage;
    public GameObject playerTwoSelectionImage;

    public Fighters GetFighterAttached()
    {
        return attachedFighter;
    }

}
