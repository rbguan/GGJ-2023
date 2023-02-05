using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataCards : MonoBehaviour
{
    [SerializeField]
    Fighters attachedFighter;

    public GameObject playerOneSelectionImage;
    public GameObject playerTwoSelectionImage;
    public Sprite characterImage;
    public Sprite tempSelectionImage;
    public Fighters GetFighterAttached()
    {
        return attachedFighter;
    }

    public Sprite GetCharacterImage()
    {
        return characterImage;
    }

    public Sprite GetTempImage()
    {
        return tempSelectionImage;
    }

}
